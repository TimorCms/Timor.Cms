using Timor.Cms.Domains.Articles;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Repository.MongoDb.Articles
{
    public class ArticleRepository : MongoDbRepository<Article>, ISingleton
    {
        public ArticleRepository(IMongoCollectionProvider mongoCollectionProvider) 
            : base(mongoCollectionProvider, "article")
        {
        }
    }
}
