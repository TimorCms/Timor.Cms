using Timor.Cms.Domains;
using Timor.Cms.Infrastructure;
using Timor.Cms.Test.Infrastructure;

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

    }
}
