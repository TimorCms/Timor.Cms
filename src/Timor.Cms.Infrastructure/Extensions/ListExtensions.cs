using System.Collections.Generic;
using System.Linq;

namespace Timor.Cms.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }
        
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return !IsNullOrEmpty(list);
        } 
    }
}