namespace Timor.Cms.Dto.BaseDto
{
    public class PaginationInput
    {
        /// <summary>
        /// 页索引，从1开始
        /// </summary>
        public int PageIndex { get; set; }
        
        /// <summary>
        /// 页大小，默认为20
        /// </summary>
        public int PageSize { get; set; }

        public int Skip => (PageIndex - 1) * PageSize;
    }
}