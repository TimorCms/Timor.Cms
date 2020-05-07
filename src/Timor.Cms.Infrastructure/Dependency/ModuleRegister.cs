using System;
using System.Linq;
using Autofac;

namespace Timor.Cms.Infrastructure.Dependency
{
    public static class ModuleRegister
    {
        public static void Regist(ContainerBuilder builder,params Type[] appModuleTypes)
        {
            var allAssemblies = appModuleTypes.Select(moduleType => moduleType.Assembly).ToArray();
            
            AutoMapperRegister.Regist(builder,allAssemblies);
            
            builder.RegisterAssemblyModules(allAssemblies);
        }
    }
}
    