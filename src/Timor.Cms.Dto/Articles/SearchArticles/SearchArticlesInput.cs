using System;
using Timor.Cms.Dto.BaseDto;

namespace Timor.Cms.Dto.Articles.SearchArticles
{
    /// <summary>
    /// 文章检索条件
    /// </summary>
    public class SearchArticlesInput : PaginationInput
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool? IsPublished { get; set; }

        /// <summary>
        /// 起始发布时间
        /// </summary>
        public DateTime? StartPublishDate { get; set; }

        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime? EndPublishDate { get; set; }

        /// <summary>
        /// 所属分类
        /// </summary>
        public string CategoryId { get; set; }
    }
}