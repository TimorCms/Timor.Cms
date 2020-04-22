using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Timor.Cms.Infrastructure.Configuration;
using Timor.Cms.PersistModels.MongoDb.Entities;


namespace Timor.Cms.Repository.MongoDb.Collections
{
    public class MongoCollectionProvider<TEntity> : IMongoCollectionProvider<TEntity> where TEntity : MongoEntityBase
    {
        private readonly ICollectionNameProvider<TEntity> _collectionNameProvider;
        private readonly string _connectionString;
        private readonly string _databaseName;

        public MongoCollectionProvider(ICollectionNameProvider<TEntity> collectionNameProvider,IOptions<DbOption> dbOption)
        {
            _collectionNameProvider = collectionNameProvider;
            
            _databaseName = dbOption.Value.DataBase;

            _connectionString = dbOption.Value.MongoConnectionString;
        }

        public IMongoCollectionAdapter<TEntity> GetCollection()
        {
            var client = new MongoClient(_connectionString);

            var dataBase = client.GetDatabase(_databaseName);

            var collectionName = _collectionNameProvider.GetCollectionName();

            var collection = dataBase.GetCollection<TEntity>(collectionName);

            IMongoCollectionAdapter<TEntity> collectionAdapter = new MongoCollectionAdapter<TEntity>(collection);

            return collectionAdapter;
        }
    }
}
