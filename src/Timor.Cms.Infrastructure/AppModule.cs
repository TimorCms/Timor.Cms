using Autofac;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Infrastructure
{
    public abstract class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            DefaultInterfaceRegister.Regist(builder, this.GetType().Assembly);

            base.Load(builder);
        }
    }
}
