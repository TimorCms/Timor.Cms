using System.Reflection;
using Timor.Cms.Infrastructure.Attributes;

namespace Timor.Cms.Repository.MongoDb.Collections.NameResolvers
{
    public class CollectionNameAttributeResolver<TEntity> : ICollectionNameResolver<TEntity>
    {
        public string ResolveCollectionName()
        {
            var collectionAttribute = typeof(TEntity).GetCustomAttribute<MongoCollectionAttribute>();

            return collectionAttribute?.CollectionName;
        }
    }
}
