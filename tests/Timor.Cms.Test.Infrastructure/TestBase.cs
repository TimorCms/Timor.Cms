using System;
using Autofac;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Test.Infrastructure
{
    public class TestBase
    {
        protected IContainer IocManager = null;

        protected IMapper Mapper { get; }

        protected IConfigurationRoot Configuration { get; }

        public TestBase(params Type[] dependAssemblies)
        {
            Configuration = ConfigurationHelper.InitConfiguration();

            BuildIocManager(dependAssemblies);

            Mapper = IocManager.Resolve<IMapper>();
        }

        private void BuildIocManager(params Type[] dependAssemblies)
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterInstance(Configuration).As<IConfiguration>().SingleInstance();
            
            RegistModule(builder, dependAssemblies);
            
            IocManager = builder.Build();
        }

        protected virtual void Regist(ContainerBuilder builder)
        {
            // empty method for children
        }

        protected void RegistModule(ContainerBuilder builder, params Type[] dependAssemblies)
        {
            Regist(builder);
            
            ModuleRegister.Regist(builder, dependAssemblies);
        }
    }
}