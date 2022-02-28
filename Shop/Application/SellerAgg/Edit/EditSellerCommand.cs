using Framework.Application;

namespace Application.SellerAgg.Edit
{
    public record EditSellerCommand(long SellerId, string ShopName, string NationalCode) : IBaseCommand;
}