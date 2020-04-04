using System;
using Autofac;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Test.Infrastructure
{
    public class TestBase
    {
        protected IContainer IocManager = null;

        public TestBase(params Type[] dependAssemblies)
        {
            var builder = new ContainerBuilder();

            RegistModule(builder, dependAssemblies);

            IocManager = builder.Build();
        }

        protected void RegistModule(ContainerBuilder builder, params Type[] dependAssemblies)
        {
            ModuleRegister.Regist(builder, dependAssemblies);
        }
    }
}
