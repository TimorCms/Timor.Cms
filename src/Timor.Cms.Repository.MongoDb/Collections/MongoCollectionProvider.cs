using AutoMapper.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Timor.Cms.Infrastructure.Configuration;
using Timor.Cms.PersistModels.MongoDb.Entities;


namespace Timor.Cms.Repository.MongoDb.Collections
{
    public class MongoCollectionProvider<TEntity> : IMongoCollectionProvider<TEntity> where TEntity : MongoEntityBase
    {
        private readonly ICollectionNameProvider<TEntity> _collectionNameProvider;

        public MongoCollectionProvider(ICollectionNameProvider<TEntity> collectionNameProvider,IOptions<DbOption> dbOption)
        {
            this._collectionNameProvider = collectionNameProvider;
            string connection1 = dbOption.Value.MongoConnectionString;

            //var connection = _configuration.("ConnectionString");
        }

        public IMongoCollectionAdapter<TEntity> GetCollection()
        {
           //  var client = new MongoClient(connec);
            
             var client = new MongoClient("mongodb://sa:123qwe@127.0.0.1:27017/admin");

            var dataBase = client.GetDatabase("TimorCms");

            var collectionName = _collectionNameProvider.GetCollectionName();

            var collection = dataBase.GetCollection<TEntity>(collectionName);

            IMongoCollectionAdapter<TEntity> collectionAdapter = new MongoCollectionAdapter<TEntity>(collection);

            return collectionAdapter;
        }
    }
}
