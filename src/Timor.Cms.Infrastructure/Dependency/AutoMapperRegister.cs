using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;

namespace Timor.Cms.Infrastructure.Dependency
{
    public static class AutoMapperRegister
    {
       
        public static void Regist(ContainerBuilder builder, Assembly[] assemblies)
        {
            List<Type> configTypes = new List<Type>();
            
            foreach (var assembly in assemblies)
            {
                var mappingConfigs =   assembly.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t));
                
                configTypes.AddRange(mappingConfigs);
            }
            
            builder.RegisterInstance(new Mapper(new MapperConfiguration(cfg =>
                {
                    foreach (var mappingConfig in configTypes)
                    {
                        cfg.AddProfile(mappingConfig);
                    }
                })))
                .As<IMapper>();
        }
    }
}