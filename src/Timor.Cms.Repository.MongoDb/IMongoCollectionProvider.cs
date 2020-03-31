using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Repository.MongoDb
{
    public interface IMongoCollectionProvider<TEntity> where TEntity : Entity<ObjectId>
    {
        IMongoCollectionAdapter<TEntity> GetCollection(string collectionName);
    }
}