using System;
using System.Collections.Generic;
using Timor.Cms.Dto.Categories;

namespace Timor.Cms.Dto.Articles.SearchArticles
{
    /// <summary>
    /// 文章搜索结果
    /// </summary>
    public class SearchArticlesDto
    {
        public string Id { get; set; }
        
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
        public string CoverImagePath { get; set; }

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
        public IList<CategoryDto> Categories { get; set; }
    }
}