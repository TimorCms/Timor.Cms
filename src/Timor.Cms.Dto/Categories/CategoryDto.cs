namespace Timor.Cms.Dto.Categories
{
    public class CategoryDto
    {
        public string Id { get; set; }

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
    }
}