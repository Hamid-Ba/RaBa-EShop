using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.SellerAgg.Create
{
    public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
        {
            RuleFor(r => r.ShopName)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(r => r.NationalCode)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("کد ملی"))
                .ValidNationalId();
        }
    }
}