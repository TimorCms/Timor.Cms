using System.Linq;
using Autofac;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Infrastructure;
using Timor.Cms.Repository.MongoDb.Collections;
using Timor.Cms.Repository.MongoDb.EntityMappings;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoDbRepositoryModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            var types = GetType().Assembly.GetTypes();
            //.Where(t => t.BaseType == typeof(MongoClassMap<>));

            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => typeof(MongoClassMap<>).IsAssignableFrom(t))
                .PublicOnly()
                .As(typeof(MongoClassMap<>))
                .SingleInstance();



            // builder.RegisterType<ArticleMapping>().As<MongoClassMap<Article>>().SingleInstance();

            builder.RegisterGeneric(typeof(CollectionNameProvider<>)).As(typeof(ICollectionNameProvider<>));

            builder.RegisterGeneric(typeof(MongoCollectionProvider<>)).As(typeof(IMongoCollectionProvider<>));

            builder.RegisterGeneric(typeof(MongoDbRepository<>)).As(typeof(IMongoDbRepository<>));

            base.Load(builder);
        }
    }
}
