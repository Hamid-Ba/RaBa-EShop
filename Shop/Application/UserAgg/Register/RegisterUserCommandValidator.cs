using FluentValidation;
using Framework.Application.Validation;

namespace Application.UserAgg.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.PhoneNumber)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("شماره همراه"))
                .Length(11)
                .WithMessage("شماره همراه 11 رقمی وارد کنید");

            RuleFor(r => r.Password)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("رمز عبور"))
                .MinimumLength(4)
                .WithMessage("حداقل رمز عبور 4 کاراکتر هست");
        }
    }
}