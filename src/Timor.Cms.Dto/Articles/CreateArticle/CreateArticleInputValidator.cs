using FluentValidation;

namespace Timor.Cms.Dto.Articles.CreateArticle
{
    /// <summary>
    /// 创建文章验证规则
    /// </summary>
    public class CreateArticleInputValidator : AbstractValidator<CreateArticleInput>
    {
        public CreateArticleInputValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(x => x.SubTitle)
                .MaximumLength(128);

            RuleFor(x => x.ShortDescription)
                .MaximumLength(1024);

            RuleFor(x => x.Content)
                .NotNull();

            RuleFor(x => x.CoverImage)
                .MaximumLength(128);

            RuleFor(x => x.Author)
                .MaximumLength(32);

            RuleFor(x => x.ReferenceUrl)
                .MaximumLength(128);
        }
    }
}