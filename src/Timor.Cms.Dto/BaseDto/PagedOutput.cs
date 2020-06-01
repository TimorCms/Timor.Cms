using System.Collections.Generic;

namespace Timor.Cms.Dto.BaseDto
{
    public class PagedOutput<T>
    {
        public PagedOutput()
        {
        }

        public PagedOutput(List<T> items, int totalCount)
        {
            TotalCount = totalCount;
            Items = items;
        }

        public int TotalCount { get; set; }

        public List<T> Items { get; set; }
    }
}