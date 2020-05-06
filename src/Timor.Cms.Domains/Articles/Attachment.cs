using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Domains.Articles
{
    public class Attachment : DomainEntityBase
    {
        /// <summary>
        /// 附件显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 原始文件名称
        /// </summary>
        /// <remarks>
        ///  主要用于在用户下载文件时，将文件名称恢复为原始文件名（因为在保存时有可能会将文件名特殊处理）
        /// </remarks>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// 附件保存的路径
        /// </summary>
        public string Path { get; set; }
    }
}
