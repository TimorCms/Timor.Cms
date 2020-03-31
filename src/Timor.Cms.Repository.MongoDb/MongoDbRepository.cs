using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Repository.MongoDb
{
    public abstract class MongoDbRepository<TEntity> where TEntity : Entity<ObjectId>
    {
        private readonly IMongoCollectionAdapter<TEntity> _collection;

        public MongoDbRepository(IMongoCollectionProvider<TEntity> collectionProvider, string collectionName)
        {
            _collection = collectionProvider.GetCollection(collectionName);
        }

        public virtual async Task<TEntity> GetById(ObjectId id)
        {
            var entity = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "插入失败!原因：参数不能为空。");
            }

            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "更新失败!原因：参数不能为空。");
            }

            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }


        public virtual async Task DeleteAsync(ObjectId id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await DeleteAsync(entity.Id);
        }

        public virtual async Task DeleteMultipleAsync(List<ObjectId> ids)
        {
            await _collection.DeleteManyAsync(Builders<TEntity>.Filter.Where(x => ids.Contains(x.Id)));
        }
    }
}