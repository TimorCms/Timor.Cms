using System;
using System.Collections.Generic;
using Timor.Cms.Domains.Ads;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Domains.Articles
{
    public class Article : AuditingDomainEntityBase
    {
        public Article()
        {
            Attachments = new List<Attachment>();
        }

        /// <summary>
        /// 主标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public Attachment CoverImage { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishDate { get; set; }

        /// <summary>
        /// 文章引用来源
        /// </summary>
        public string ReferenceUrl { get; set; }
        
        /// <summary>
        /// 访问次数
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        /// 文章分类
        /// </summary>
        public IList<Category> Categories { get; set; }

        /// <summary>
        /// 文章的广告列表，针对文章而显示的一些Banner
        /// </summary>
        /// <remarks>
        /// </remarks>
        public IList<Ad> Ads { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public IList<Attachment> Attachments { get; set; }

        /// <summary>
        /// SEO信息
        /// </summary>
        public Seo Seo { get; set; }
    }
}