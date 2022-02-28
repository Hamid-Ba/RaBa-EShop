using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.SellerAgg.Edit
{
    public class EditSellerCommandValidatior : AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidatior()
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