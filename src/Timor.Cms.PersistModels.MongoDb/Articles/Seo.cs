using Timor.Cms.PersistModels.MongoDb.Entities;

namespace Timor.Cms.PersistModels.MongoDb.Articles
{
    public class Seo : AuditingMongoEntityBase
    {

        /// <summary>
        /// 定制化的URL
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// 定制页面Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Meta Keywords
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// Meta Description
        /// </summary>
        public string Description { get; set; }
    }
}
