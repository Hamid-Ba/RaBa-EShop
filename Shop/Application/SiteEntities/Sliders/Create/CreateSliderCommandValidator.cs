using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Link)
                .NotNull().NotEmpty()
                .WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.ImageName)
                .NotNull()
                .WithMessage(ValidationMessages.required("لینک"))
                .JustImageFile();
        }
    }
}
