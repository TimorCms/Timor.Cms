using System;
using Autofac;
using AutoMapper;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Test.Infrastructure
{
    public class TestBase
    {
        protected IContainer IocManager = null;
        
        protected IMapper Mapper { get; }

        public TestBase(params Type[] dependAssemblies)
        {
            var builder = new ContainerBuilder();

            RegistModule(builder, dependAssemblies);

            IocManager = builder.Build();

            Mapper = IocManager.Resolve<IMapper>();
        }

        protected void RegistModule(ContainerBuilder builder, params Type[] dependAssemblies)
        {
            ModuleRegister.Regist(builder, dependAssemblies);
        }
    }
}
