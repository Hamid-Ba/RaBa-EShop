using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.ProductAgg.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Description)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("اسلاگ"));

            RuleFor(r => r.ImageName)
                .NotNull()
                .WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();
        }
    }
}
