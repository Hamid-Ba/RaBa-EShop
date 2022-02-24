using FluentValidation;

namespace Application.OrderAgg.ChangeCount
{
    public class ChangeCountCommandValidator : AbstractValidator<ChangeCountCommand>
    {
        public ChangeCountCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1)
                .WithMessage("حداقل تعداد 1 می تواند باشد");
        }
    }
}