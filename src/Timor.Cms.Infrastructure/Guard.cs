using System;

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
