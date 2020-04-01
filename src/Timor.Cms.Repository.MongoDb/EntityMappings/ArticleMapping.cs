using Timor.Cms.Domains.Articles;

namespace Timor.Cms.Repository.MongoDb.EntityMappings
{
    public class ArticleMapping : MongoClassMap<Article>
    {
        public ArticleMapping()
        {
            MapCollectionName("article");
        }
    }
}