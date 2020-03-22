using System;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Service
{
    public class TestService : ISingleton
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
