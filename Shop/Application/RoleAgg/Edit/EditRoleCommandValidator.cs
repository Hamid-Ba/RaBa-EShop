using FluentValidation;
using Framework.Application.Validation;

namespace Application.RoleAgg.Edit
{
    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}