using System.Reflection;
using Autofac;

namespace Timor.Cms.Infrastructure.Dependency
{
    public class DefaultInterfaceRegister
    {
        public static void Regist(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof(ISingleton).IsAssignableFrom(t))
                .PublicOnly()
                .SingleInstance();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableFrom(typeof(ITransient)))
                .PublicOnly()
                .InstancePerDependency();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableFrom(typeof(IScoped)))
                .PublicOnly()
                .InstancePerRequest();
        }
    }
}
