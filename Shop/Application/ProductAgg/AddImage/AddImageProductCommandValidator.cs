using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.ProductAgg.AddImage
{
    public class AddImageProductCommandValidator : AbstractValidator<AddImageProductCommand>
    {
        public AddImageProductCommandValidator()
        {
            RuleFor(r => r.Sequence)
                .GreaterThanOrEqualTo(0)
                .WithMessage("حداقل ارزش 0 می تواند باشد");

            RuleFor(r => r.ImageName)
                .NotNull()
                .WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();
        }
    }
}