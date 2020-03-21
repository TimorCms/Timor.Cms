using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Domains.Articles
{
    /// <summary>
    /// 文章标签
    /// </summary>
    public class Tag : AuditingEntity
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
