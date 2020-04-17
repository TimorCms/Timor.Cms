using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Timor.Cms.Domains;
using Timor.Cms.Infrastructure;
using Timor.Cms.Infrastructure.Configuration;
using Timor.Cms.Test.Infrastructure;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.IntegrationTests
{
    public abstract class MongoDbRepositoryTestBase : TestBase
    {
        protected MongoDbRepositoryTestBase()
            :base(typeof(InfrastructureModule),
            typeof(DomainModule),
            typeof(MongoDbRepositoryModule))
        {
            
        }

        protected override void Regist(ContainerBuilder builder)
        {
            builder.RegisterInstance(
                Options.Create(new DbOption
                {
                    MongoConnectionString = Configuration.GetConnectionString("MongoDbForTest")
                })
            ).As<IOptions<DbOption>>();
            
            base.Regist(builder);
        }
    }
}
