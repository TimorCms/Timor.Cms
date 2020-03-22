using System;
using System.Linq;
using Autofac;

namespace Timor.Cms.Infrastructure.Dependency
{
    public class ModuleRegister
    {
        public static void Regist(ContainerBuilder builder,params Type[] appModuleTypes)
        {
            builder.RegisterAssemblyModules(appModuleTypes.Select(moduleType => moduleType.Assembly).ToArray());
        }
    }
}
    