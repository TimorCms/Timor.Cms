namespace Timor.Cms.Repository.MongoDb.Collections.NameResolvers
{
    public class CollectionNameDefaultResolver<TEntity> : ICollectionNameResolver<TEntity>
    {
        public string ResolveCollectionName()
        {
            return typeof(TEntity).Name;
        }
    }
}
