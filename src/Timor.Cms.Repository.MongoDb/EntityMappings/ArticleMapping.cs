using MongoDB.Bson.Serialization;
using Timor.Cms.Domains.Articles;

namespace Timor.Cms.Repository.MongoDb.EntityMappings
{
    public class ArticleMapping : BsonClassMap<Article>
    {
        public ArticleMapping()
        {
            
        }
    }
}