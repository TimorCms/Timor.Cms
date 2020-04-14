using System;

namespace Timor.Cms.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MongoCollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }

        public MongoCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
