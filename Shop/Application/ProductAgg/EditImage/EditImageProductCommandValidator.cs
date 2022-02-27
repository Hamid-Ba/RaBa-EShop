using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.ProductAgg.EditImage
{
    public class EditImageProductCommandValidator : AbstractValidator<EditImageProductCommand>
    {
        public EditImageProductCommandValidator()
        {
            RuleFor(r => r.Sequence)
                .GreaterThanOrEqualTo(0)
                .WithMessage("حداقل ارزش 0 می تواند باشد");

            RuleFor(r => r.ImageFile)
                .NotNull()
                .WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();
        }
    }

}