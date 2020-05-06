using System.Collections.Generic;

namespace Timor.Cms.Dto.Articles.CreateArticle
{
    /// <summary>
    /// 创建文章请求
    /// </summary>
    public class CreateArticleInput
    {
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
        public string CoverImage { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// 文章引用来源
        /// </summary>
        public string ReferenceUrl { get; set; }
        
        /// <summary>
        /// 访问次数
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public IList<string> CategoryIds { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public IList<string> AttachmentIds { get; set; }
    }
}