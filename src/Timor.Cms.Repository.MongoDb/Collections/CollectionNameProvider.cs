using System.Collections.Generic;
using Timor.Cms.Repository.MongoDb.Collections.NameResolvers;
using Timor.Cms.Repository.MongoDb.EntityMappings;

namespace Timor.Cms.Repository.MongoDb.Collections
{
    public class CollectionNameProvider<TEntity> : ICollectionNameProvider<TEntity>
    {
        private readonly List<ICollectionNameResolver<TEntity>> _collectionNameResolvers;

        public virtual MongoClassMap<TEntity> ClassMap { get; set; }

        public CollectionNameProvider()
        {
            _collectionNameResolvers = new List<ICollectionNameResolver<TEntity>>
            {
                new CollectionNameAttributeResolver<TEntity>(),
                new CollectionNameClassMapResolver<TEntity>(ClassMap),
                new CollectionNameDefaultResolver<TEntity>()
            };
        }


        public string GetCollectionName()
        {
            string collectionName = null;

            foreach (var resolver in _collectionNameResolvers)
            {
                collectionName = resolver.ResolveCollectionName();

                if (!string.IsNullOrWhiteSpace(collectionName))
                {
                    break;
                }
            }

            return collectionName;
        }
    }
}
