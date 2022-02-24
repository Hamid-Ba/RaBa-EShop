using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.OrderAgg.Checkout
{
    public class CheckoutCommandValidator : AbstractValidator<CheckoutCommand>
    {
        public CheckoutCommandValidator()
        {
            RuleFor(i => i.FullName)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(i => i.PhoneNumber)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("شماره همراه"))
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage("تعداد کاراکتر باید 11 تا باشد");

            RuleFor(i => i.PostalCode)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("کد پستی"));

            RuleFor(i => i.Province)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("استان"));

            RuleFor(i => i.City)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(i => i.Address)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("آدرس"));

            RuleFor(i => i.NationalCode)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("آدرس"))
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage("تعداد کاراکتر باید 10 تا باشد")
                .ValidNationalId();
        }
    }
}