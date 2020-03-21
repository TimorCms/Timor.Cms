using System.Collections.Generic;
using Timor.Cms.Domains.Ads;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Domains.Articles
{
    /// <summary>
    /// 分类
    /// </summary>
    public class Category : AuditingEntity
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 分类下的文章
        /// </summary>
        public IList<Article> Articles { get; set; }

        /// <summary>
        /// 父分类
        /// </summary>
        public Category ParentCategory { get; set; }

        /// <summary>
        /// 子分类
        /// </summary>
        public IList<Category> SubCategories { get; set; }

        /// <summary>
        /// 分类的广告列表
        /// </summary>
        public IList<Ad> Ads { get; set; }

        /// <summary>
        /// 分类SEO信息
        /// </summary>
        public Seo Seo { get; set; }
    }
}
