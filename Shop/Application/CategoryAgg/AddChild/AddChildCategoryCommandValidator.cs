using FluentValidation;
using Framework.Application.Validation;

namespace Application.CategoryAgg.AddChild
{
    public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(c => c.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.Required);
        }
    }
}
