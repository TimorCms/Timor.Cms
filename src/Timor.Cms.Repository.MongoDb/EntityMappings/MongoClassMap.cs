using MongoDB.Bson.Serialization;

namespace Timor.Cms.Repository.MongoDb.EntityMappings
{
    public class MongoClassMap<TEntity> : BsonClassMap<TEntity>
    {
        private string _collectionName;

        public void MapCollectionName(string collectionName)
        {
            _collectionName = collectionName;
        }

        public string GetCollectionName()
        {
            return _collectionName;
        }
    }
}
