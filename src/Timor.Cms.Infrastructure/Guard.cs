using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timor.Cms.Infrastructure
{
    public static class Guard
    {
        public static void NotNull<T>(T t,string message)
        {
            if (t == null) throw new ArgumentNullException(message);
        }
    }
}
