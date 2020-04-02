using Timor.Cms.Repository.MongoDb.EntityMappings;

namespace Timor.Cms.Repository.MongoDb.Collections.NameResolvers
{
    public class CollectionNameClassMapResolver<TEntity> : ICollectionNameResolver<TEntity>
    {
        private readonly MongoClassMap<TEntity> _classMap;

        public CollectionNameClassMapResolver(MongoClassMap<TEntity> classMap)
        {
            _classMap = classMap;
        }

        public string ResolveCollectionName()
        {
            return _classMap?.GetCollectionName();
        }
    }
}
