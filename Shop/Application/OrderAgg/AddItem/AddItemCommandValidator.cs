using FluentValidation;

namespace Application.OrderAgg.AddItem
{
    public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
    {
        public AddItemCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("حداقل تعداد 1 می تواند باشد");
        }
    }
}
