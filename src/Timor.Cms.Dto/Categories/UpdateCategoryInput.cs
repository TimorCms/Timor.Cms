namespace Timor.Cms.Dto.Categories
{
    /// <summary>
    /// 修改文章分类Request
    /// </summary>
    public class UpdateCategoryInput
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
        /// 父分类ID
        /// </summary>
        public string ParentCategoryId { get; set; }
    }
}
