using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;

namespace Timor.Cms.Infrastructure.Dependency
{
    public class AutoMapperRegister
    {
        public static void Regist(ContainerBuilder builder, Assembly assembly)
        {
            var mappingConfigs = assembly.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t));

            builder.RegisterInstance(new Mapper(new MapperConfiguration(cfg =>
                {
                    foreach (var mappingConfig in mappingConfigs)
                    {
                        cfg.AddProfile(mappingConfig);
                    }
                })))
                .As<IMapper>();
        }
    }
}