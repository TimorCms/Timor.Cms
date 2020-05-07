using FluentValidation;

namespace Timor.Cms.Dto.Accounts
{
    public class LoginInputValidator : AbstractValidator<LoginInput>
    {
        public LoginInputValidator()
        {
            RuleFor(x => x.LoginName)
                .NotNull()
                .NotEmpty()
                .Length(3, 16);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}