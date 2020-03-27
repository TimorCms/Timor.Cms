using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Timor.Cms.Domains.Entities
{
    public abstract class Entity : Entity<ObjectId>
    {

    }

    public abstract class Entity<TPrimaryKey>
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public TPrimaryKey Id { get; set; }
    }
}
