using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Repository.MongoDb
{
    public interface IMongoCollectionProvider
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName) where TEntity : Entity<ObjectId>;
    }
}