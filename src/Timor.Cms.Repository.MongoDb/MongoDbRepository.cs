using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Infrastructure;
using Timor.Cms.Infrastructure.Sessions;
using Timor.Cms.PersistModels.MongoDb.Entities;
using Timor.Cms.Repository.MongoDb.Collections;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : MongoEntityBase
    {
        private readonly IMongoCollectionAdapter<TEntity> _collection;
        private readonly ObjectId? _userId;

        public MongoDbRepository(IMongoCollectionProvider<TEntity> collectionProvider, ISession session, IMapper mapper)
        {
            _userId = mapper.Map<ObjectId?>(session.UserId);
            _collection = collectionProvider.GetCollection();
        }

        public virtual async Task<TEntity> GetByIdAsync(ObjectId id)
        {
            var entity = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            Guard.NotNull(entity, "插入失败!原因：参数不能为空。");

            if (entity is AuditingMongoEntityBase auditingEntity)
            {
                auditingEntity.CreateTime = DateTime.Now;
                auditingEntity.CreateUserId = _userId;
            }

            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Guard.NotNull(entity, "更新失败!原因：参数不能为空。");

            var result = await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

            if (entity is AuditingMongoEntityBase auditingEntity)
            {
                auditingEntity.LastModifyTime = DateTime.Now;
                auditingEntity.LastModifyUserId = _userId;
            }

            if (result.MatchedCount < 1)
            {
                throw new KeyNotFoundException("更新失败，未找到要更新的数据。");
            }
        }


        public virtual async Task DeleteAsync(ObjectId id)
        {
            if (typeof(TEntity).IsAuditEntity())
            {
                var entity = await GetByIdAsync(id);

                await DeleteAsync(entity);
            }
            else
            {
                var result = await _collection.DeleteOneAsync(x => x.Id == id);

                if (result.DeletedCount < 1)
                {
                    throw new KeyNotFoundException("更新失败，未找到要删除的数据。");
                }
            }
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            Guard.NotNull(entity, "删除失败，未找到要删除的数据");

            if (entity is AuditingMongoEntityBase auditingEntity)
            {
                auditingEntity.IsDelete = true;
                auditingEntity.DeleteTime = DateTime.Now;
                auditingEntity.DeleteUserId = _userId;
                await UpdateAsync(entity);
            }
            else
            {
                await DeleteAsync(entity.Id);
            }
        }

        public virtual async Task DeleteMultipleAsync(IEnumerable<ObjectId> ids)
        {
            if (typeof(TEntity).IsAuditEntity())
            {
                var update = Builders<TEntity>.Update;
                update.SetOnInsert(nameof(AuditingMongoEntityBase.IsDelete), true);
                update.SetOnInsert(nameof(AuditingMongoEntityBase.DeleteTime), DateTime.Now);
                update.SetOnInsert(nameof(AuditingMongoEntityBase.DeleteUserId), _userId);

                await _collection.UpdateMany(Builders<TEntity>.Filter.Where(x => ids.Contains(x.Id)),
                    update.Combine());
            }
            else
            {
                await _collection.DeleteManyAsync(Builders<TEntity>.Filter.Where(x => ids.Contains(x.Id)));
            }
        }

        public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _collection.Find(condition.ApplySoftDeleteFilter()).ToListAsync();
        }

        public IFindFluent<TEntity, TEntity> Find(Expression<Func<TEntity, bool>> condition)
        {
            return _collection.Find(condition.ApplySoftDeleteFilter());
        }

        public IFindFluent<TEntity, TEntity> Find(FilterDefinition<TEntity> filter)
        {
            if (typeof(TEntity).IsAuditEntity())
            {
                filter = filter & Builders<TEntity>.Filter.Eq(nameof(AuditingMongoEntityBase.IsDelete), false);
            }

            return _collection.Find(filter);
        }

        public virtual async Task<TEntity> FindFirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _collection.Find(condition.ApplySoftDeleteFilter()).FirstOrDefaultAsync();
        }


        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter)
            => _collection.Find(filter.ApplySoftDeleteFilter()).AnyAsync();
    }

    public static class ExpressionExtension
    {
        public static Expression<Func<TEntity, bool>> ApplySoftDeleteFilter<TEntity>(
            this Expression<Func<TEntity, bool>> originalCondition)
        {
            if (typeof(TEntity).IsAuditEntity())
            {
                // x => 
                var parameter = Expression.Parameter(typeof(TEntity), "x");

                var softDeleteFilter =
                    Expression.Equal(
                        Expression.Property(parameter, nameof(AuditingMongoEntityBase.IsDelete)),
                        Expression.Constant(false));

                // x.IsDelete == true && condition
                var finallyCondition = Expression.And(originalCondition.Body, softDeleteFilter);

                var lambda = Expression.Lambda<Func<TEntity, bool>>(finallyCondition, parameter);

                return lambda;
            }

            return originalCondition;
        }
    }

    public static class TypeExtension
    {
        public static bool IsAuditEntity(this Type type)
        {
            return type.IsAssignableFrom(typeof(AuditingMongoEntityBase));
        }
    }
}