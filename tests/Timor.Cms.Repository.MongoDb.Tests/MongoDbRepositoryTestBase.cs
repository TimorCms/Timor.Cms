using Timor.Cms.Domains;
using Timor.Cms.Infrastructure;
using Timor.Cms.Test.Infrastructure;

namespace Timor.Cms.Repository.MongoDb.Tests
{
    public abstract class MongoDbRepositoryTestBase : TestBase
    {
        public MongoDbRepositoryTestBase() 
            : base(typeof(InfrastructureModule),
            typeof(DomainModule),
            typeof(MongoDbRepositoryModule))
        {

        }
    }
}
