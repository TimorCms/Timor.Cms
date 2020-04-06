using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Entities;
using Timor.Cms.Repository.MongoDb.Collections;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : Entity<ObjectId>
    {
        private readonly IMongoCollectionAdapter<TEntity> _collection;

        public MongoDbRepository(IMongoCollectionProvider<TEntity> collectionProvider)
        {
            _collection = collectionProvider.GetCollection();
        }

        public virtual async Task<TEntity> GetByIdAsync(ObjectId id)
        {
            var entity = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "����ʧ��!ԭ�򣺲�������Ϊ�ա�");
            }

            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "����ʧ��!ԭ�򣺲�������Ϊ�ա�");
            }

            var result = await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

            if (result.MatchedCount < 1)
            {
                throw new KeyNotFoundException("����ʧ�ܣ�δ�ҵ�Ҫ���µ����ݡ�");
            }
        }


        public virtual async Task DeleteAsync(ObjectId id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount < 1)
            {
                throw new KeyNotFoundException("����ʧ�ܣ�δ�ҵ�Ҫ���µ����ݡ�");
            }
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity),"ɾ��ʧ�ܣ�δ�ҵ�Ҫɾ��������");
            }

            await DeleteAsync(entity.Id);
        }

        public virtual async Task DeleteMultipleAsync(IEnumerable<ObjectId> ids)
        {
            await _collection.DeleteManyAsync(Builders<TEntity>.Filter.Where(x => ids.Contains(x.Id)));
        }
    }
}