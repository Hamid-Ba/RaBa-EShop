using FluentValidation;
using Framework.Application.Validation;

namespace Application.UserAgg.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(r => r.FirstName)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.LastName)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(r => r.PhoneNumber)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("شماره همراه"))
                .Length(11)
                .WithMessage("شماره همراه 11 رقمی وارد کنید");
        }
    }
}