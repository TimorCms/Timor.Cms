using Autofac;
using FluentValidation;
using Timor.Cms.Dto.Categories;
using Timor.Cms.Infrastructure;

namespace Timor.Cms.Dto
{
#pragma warning disable CS1591
    public class DtoModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InsertCategoryInputValidator>().As<IValidator<InsertCategoryInput>>();

            base.Load(builder);
        }
    }
#pragma warning restore CS1591
}
