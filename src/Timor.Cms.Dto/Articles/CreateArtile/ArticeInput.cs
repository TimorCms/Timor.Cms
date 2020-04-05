using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timor.Cms.Dto.Articles.CreateArtile
{
    /// <summary>
    /// 文章
    /// </summary>
    public class ArticeInput
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
        public ObjectId ImageId { get; set; }

        /// <summary>
        /// 附件 
        /// </summary>
        public List<ObjectId> AttachmentIds { get; set; }

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
    }
}
