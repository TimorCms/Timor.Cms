using Autofac;
using Timor.Cms.Domains;
using Timor.Cms.Infrastructure;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Repository.MongoDb.Tests
{
    public abstract class MongoDbRepositoryTestBase
    {
        protected IContainer IocManager = null;

        public MongoDbRepositoryTestBase()
        {
            var builder = new ContainerBuilder();

            RegistModule(builder);

            IocManager = builder.Build();
        }

        protected void RegistModule(ContainerBuilder builder)
        {
            ModuleRegister.Regist(builder,
                typeof(InfrastructureModule),
                typeof(DomainModule),
                typeof(MongoDbRepositoryModule));
        }
    }
}
