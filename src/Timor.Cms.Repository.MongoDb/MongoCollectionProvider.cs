using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Entities;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoCollectionProvider : IMongoCollectionProvider
    {
        public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName) where TEntity : Entity<ObjectId>
        {
            var client = new MongoClient("mongodb://sa:123qwe@127.0.0.1:27017/admin");

            var dataBase = client.GetDatabase("TimorCms");

            var collection = dataBase.GetCollection<TEntity>(collectionName);

            return collection;
        }
    }
}
