using FluentValidation;
using Framework.Application.Validation;

namespace Application.CategoryAgg.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(c => c.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.Required);
        }
    }
}
