using Framework.Application;

namespace Application.SellerAgg.Create
{
    public record CreateSellerCommand(long UserId, string ShopName, string NationalCode) : IBaseCommand;
}