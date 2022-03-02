using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandValidator : AbstractValidator<EditSliderCommand>
    {
        public EditSliderCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Link)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.ImageFile)
                .NotNull()
                .WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();
        }
    }
}
