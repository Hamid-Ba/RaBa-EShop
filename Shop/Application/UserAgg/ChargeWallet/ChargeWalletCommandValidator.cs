using FluentValidation;
using Framework.Application.Validation;

namespace Application.UserAgg.ChargeWallet
{
    public class ChargeWalletCommandValidator : AbstractValidator<ChargeWalletCommand>
    {
        public ChargeWalletCommandValidator()
        {
            RuleFor(r => r.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ValidationMessages.required("مبلغ"));
        }
    }
}

