using System.Reflection;
using Timor.Cms.Repository.MongoDb.Attributes;

namespace Timor.Cms.Repository.MongoDb.Collections.NameResolvers
{
    public class CollectionNameAttributeResolver<TEntity> : ICollectionNameResolver<TEntity>
    {
        public string ResolveCollectionName()
        {
            var collectionAttribute = typeof(TEntity).GetCustomAttribute<MogoCollectionAttribute>();

            return collectionAttribute?.CollectionName;
        }
    }
}
