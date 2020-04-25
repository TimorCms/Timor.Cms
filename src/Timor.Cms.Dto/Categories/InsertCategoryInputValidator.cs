using FluentValidation;

namespace Timor.Cms.Dto.Categories
{
    /// <summary>
    /// 新增文章分类验证规则
    /// </summary>
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
