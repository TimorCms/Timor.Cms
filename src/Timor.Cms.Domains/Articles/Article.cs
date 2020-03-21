using System;
using System.Collections.Generic;
using Timor.Cms.Domains.Ads;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Domains.Articles
{
    public class Article : AuditingEntity
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
        public Attachment CoverImageUrl { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishDate { get; set; }

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
        /// 文章的广告列表
        /// </summary>
        /// <remarks>
        /// 我相信大部分情况下，这个字段没啥用，但是偶尔如果有需求针对一些文章详情页加一些Banner之类的图，这个字段就会派上用场
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