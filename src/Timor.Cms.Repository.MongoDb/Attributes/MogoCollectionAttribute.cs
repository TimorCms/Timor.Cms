using System;

namespace Timor.Cms.Repository.MongoDb.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MogoCollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }

        public MogoCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
