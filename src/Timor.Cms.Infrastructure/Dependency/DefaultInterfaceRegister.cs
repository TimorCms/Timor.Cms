using System;
using System.Linq;
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
                .As(GetRegisterAsType)
                .PublicOnly()
                .SingleInstance();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableFrom(typeof(ITransient)))
                .As(GetRegisterAsType)
                .PublicOnly()
                .InstancePerDependency();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableFrom(typeof(IScoped)))
                .As(GetRegisterAsType)
                .PublicOnly()
                .InstancePerRequest();
        }

        private static Type GetRegisterAsType(Type registerType)
        {
            if (registerType.GetInterfaces().Length > 1)
            {
                return registerType.GetInterfaces().First(x => !typeof(ISingleton).IsAssignableFrom(registerType));
            }

            return registerType;
        }
    }
}
