using Autofac;
using Timor.Cms.Infrastructure;
using Timor.Cms.Repository.MongoDb.Collections;
using Timor.Cms.Repository.MongoDb.EntityMappings;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoDbRepositoryModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(x=>x.IsPublic)
                .Where(t => t.BaseType != null
                            && t.BaseType.IsGenericType
                            && t.BaseType.GetGenericTypeDefinition() == typeof(MongoClassMap<>))
                .PublicOnly()
                .As(t => t.BaseType)
                .SingleInstance();

            builder
                .RegisterGeneric(typeof(CollectionNameProvider<>))
                .PropertiesAutowired();

            builder
                .RegisterGeneric(typeof(CollectionNameProvider<>))
                .As(typeof(ICollectionNameProvider<>));
                

            builder.RegisterGeneric(typeof(MongoCollectionProvider<>)).As(typeof(IMongoCollectionProvider<>));

            builder.RegisterGeneric(typeof(MongoDbRepository<>)).As(typeof(IMongoDbRepository<>));

            base.Load(builder);
        }
    }
}
