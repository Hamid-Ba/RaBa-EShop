using FluentValidation;
using Framework.Application.Validation;

namespace Application.UserAgg.AddToken
{
    public class AddTokenCommandValidator : AbstractValidator<AddTokenCommand>
    {
        public AddTokenCommandValidator()
        {
            RuleFor(r => r.HashToken)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("توکن"));

            RuleFor(r => r.RefreshTokenExpireDate)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("رفرش توکن"));

            RuleFor(r => r.Device)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("دستگاه"));
        }
    }
}
