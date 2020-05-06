using FluentValidation;

namespace Timor.Cms.Dto.Categories
{
    /// <summary>
    /// 更新文章分类验证规则
    /// </summary>
    public class UpdateCategoryInputValidator : AbstractValidator<UpdateCategoryInput>
    {
        public UpdateCategoryInputValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(16);
        }
    }
}
