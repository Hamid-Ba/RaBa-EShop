using Application.ProductAgg.Edit;
using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
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

        RuleFor(r => r.ImageFile)
            .JustImageFile();
    }
}