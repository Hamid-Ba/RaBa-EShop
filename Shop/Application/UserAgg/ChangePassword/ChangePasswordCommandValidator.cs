using FluentValidation;
using Framework.Application.Validation;

namespace Application.UserAgg.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(r => r.NewPassword)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("رمز عبور"))
                .MinimumLength(4)
                .WithMessage("حداقل رمز عبور 4 کاراکتر هست");
        }
    }
}