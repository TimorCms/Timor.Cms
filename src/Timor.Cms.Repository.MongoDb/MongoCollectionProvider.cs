using MongoDB.Driver;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoCollectionProvider
    {
        public static IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
        {
            var client = new MongoClient("mongodb://sa:123qwe@127.0.0.1:27017/admin");

            var dataBase = client.GetDatabase("TimorCms");

            var collection = dataBase.GetCollection<TEntity>(collectionName);

            return collection;
        }
    }
}
