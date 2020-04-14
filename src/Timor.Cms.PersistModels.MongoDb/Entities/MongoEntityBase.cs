using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Timor.Cms.PersistModels.MongoDb.Entities
{
    public abstract class MongoEntityBase
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public ObjectId Id { get; set; }
    }
}
