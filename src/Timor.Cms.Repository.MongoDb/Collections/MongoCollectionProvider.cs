using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Entities;


namespace Timor.Cms.Repository.MongoDb.Collections
{
    public class MongoCollectionProvider<TEntity> : IMongoCollectionProvider<TEntity> where TEntity : Entity<ObjectId>
    {
        private ICollectionNameProvider<TEntity> _collectionNameProvider;
        //private IConfiguration _configuration;

        public MongoCollectionProvider(ICollectionNameProvider<TEntity> collectionNameProvider)
        {
            this._collectionNameProvider = collectionNameProvider;
            //_configuration = configuration;

            //var connection = _configuration.GetConnectionString("ConnectionString");
        }

        public IMongoCollectionAdapter<TEntity> GetCollection()
        {
            var client = new MongoClient("mongodb://sa:123qwe@127.0.0.1:27017/admin");

            var dataBase = client.GetDatabase("TimorCms");

            var collectionName = _collectionNameProvider.GetCollectionName();

            var collection = dataBase.GetCollection<TEntity>(collectionName);

            IMongoCollectionAdapter<TEntity> collectionAdapter = new MongoCollectionAdapter<TEntity>(collection);

            return collectionAdapter;
        }
    }
}
