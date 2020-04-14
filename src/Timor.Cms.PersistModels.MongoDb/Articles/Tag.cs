using Timor.Cms.PersistModels.MongoDb.Entities;

namespace Timor.Cms.PersistModels.MongoDb.Articles
{
    /// <summary>
    /// 文章标签
    /// </summary>
    public class Tag : AuditingMongoEntityBase
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tag SEO信息
        /// </summary>
        public Seo Seo { get; set; }
    }
}
