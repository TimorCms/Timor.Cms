using System;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Domains.Articles
{
    public class Seo : AuditingEntity
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
