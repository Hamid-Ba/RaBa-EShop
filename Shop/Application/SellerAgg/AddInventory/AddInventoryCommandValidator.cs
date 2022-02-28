using FluentValidation;

namespace Application.SellerAgg.AddInventory
{
    public class AddInventoryCommandValidator : AbstractValidator<AddInventoryCommand>
    {
        public AddInventoryCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(0)
                .WithMessage("حداقل تعداد 0 می باشد");

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("قیمت را به درستی وارد نمایید");
        }
    }
}
