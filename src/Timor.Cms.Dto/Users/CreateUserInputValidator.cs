using FluentValidation;

namespace Timor.Cms.Dto.Users
{
    public class CreateUserInputValidator: AbstractValidator<CreateUserInput>
    {
        public CreateUserInputValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(16);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(32);

            RuleFor(x => x.PhoneNumber)
                .Matches("")
                .WithMessage("手机号码格式错误！")
                .MaximumLength(16);
        }
    }
}