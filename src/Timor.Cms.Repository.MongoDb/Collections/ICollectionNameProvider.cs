namespace Timor.Cms.Repository.MongoDb.Collections
{
    public interface ICollectionNameProvider<TEntity>
    {
        string GetCollectionName();
    }
}