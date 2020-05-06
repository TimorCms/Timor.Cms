using System.Linq;
using Autofac;
using FluentValidation;
using Timor.Cms.Infrastructure;

namespace Timor.Cms.Dto
{
#pragma warning disable CS1591
    public class DtoModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(x=>x.IsPublic)
                .Where(t => t.BaseType != null
                            && t.BaseType.IsGenericType
                            && t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                .PublicOnly()
                .As(t=> t.GetInterfaces().Where(i=> typeof(IValidator).IsAssignableFrom(i) && i.IsGenericType))
                .SingleInstance();
            
            base.Load(builder);
        }
    }
#pragma warning restore CS1591
}
