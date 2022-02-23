using FluentValidation;
using Framework.Application.Validation;

namespace Application.CategoryAgg.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(c => c.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.Required);
        }
    }
}