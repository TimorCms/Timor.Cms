using FluentValidation;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Dto.Categories
{
    public class InsertCategoryInputValidator : AbstractValidator<InsertCategoryInput>
    {
        public InsertCategoryInputValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(16);
        }

    }
}
