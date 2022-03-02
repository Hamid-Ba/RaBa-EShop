using FluentValidation;
using Framework.Application.Validation;
using Framework.Application.Validation.FluentValidations;

namespace Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(r => r.Link)
                .NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.ImageName)
                .NotNull().WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();
        }
    }
}
