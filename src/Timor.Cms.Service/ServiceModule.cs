using Autofac;
using AutoMapper;
using Timor.Cms.Infrastructure;

namespace Timor.Cms.Service
{
    public class ServiceModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerMapper>();
            })))
            .As<IMapper>();

            base.Load(builder);
        }
    }
}
