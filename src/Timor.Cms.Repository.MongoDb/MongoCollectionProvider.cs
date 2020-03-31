using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoCollectionProvider<TEntity> : IMongoCollectionProvider<TEntity> where TEntity : Entity<ObjectId>
    {

        public IMongoCollectionAdapter<TEntity> GetCollection(string collectionName) 
        {
            var client = new MongoClient("mongodb://sa:123qwe@127.0.0.1:27017/admin");

            var dataBase = client.GetDatabase("TimorCms");

            var collection = dataBase.GetCollection<TEntity>(collectionName);

            IMongoCollectionAdapter<TEntity> collectionAdapter = new MongoCollectionAdapter<TEntity>(collection);

            return collectionAdapter;
        }
    }
}
