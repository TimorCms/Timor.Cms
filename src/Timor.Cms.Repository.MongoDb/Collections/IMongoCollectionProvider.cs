using MongoDB.Bson;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Repository.MongoDb.Collections
{
    public interface IMongoCollectionProvider<TEntity> where TEntity : Entity<ObjectId>
    {
        IMongoCollectionAdapter<TEntity> GetCollection();
    }
}