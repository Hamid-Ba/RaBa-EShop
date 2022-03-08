using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.UserAgg.AddAddress
{
    public class AddAddressCommandValidator : AbstractValidator<AddAddressCommand>
    {
        public AddAddressCommandValidator()
        {
            RuleFor(r => r.FullName)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.PhoneNumber)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("شماره همراه"))
                .Length(11)
                .WithMessage("شماره همراه 11 رقمی وارد کنید");

            RuleFor(r => r.Province)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("استان"));

            RuleFor(r => r.City)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(r => r.Address)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("آدرس"));

            RuleFor(r => r.PostalCode)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("کد پستی"));

            RuleFor(r => r.NationalCode)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("کد ملی"))
                .ValidNationalId();
        }
    }
}

