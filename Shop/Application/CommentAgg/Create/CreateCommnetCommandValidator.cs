using FluentValidation;
using Framework.Application.Validation;

namespace Application.CommentAgg.Create
{
    public class CreateCommnetCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommnetCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("متن"));
        }
    }
}