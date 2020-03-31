using Autofac;
using Timor.Cms.Infrastructure;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoDbRepositoryModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(MongoCollectionProvider<>)).As(typeof(IMongoCollectionProvider<>));

            base.Load(builder);
        }
    }
}
