using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
    {
        public EditBannerCommandValidator()
        {
            RuleFor(r => r.Link)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();
        }
    }
}