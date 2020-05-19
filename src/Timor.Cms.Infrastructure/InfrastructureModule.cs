using Autofac;
using Timor.Cms.Infrastructure.Sessions;

namespace Timor.Cms.Infrastructure
{
    public class InfrastructureModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Session>().As<ISession>().InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}
