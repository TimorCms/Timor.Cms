namespace Timor.Cms.Repository.MongoDb.Collections.NameResolvers
{
    public interface ICollectionNameResolver<TEntity>
    {
        string ResolveCollectionName();
    }
}