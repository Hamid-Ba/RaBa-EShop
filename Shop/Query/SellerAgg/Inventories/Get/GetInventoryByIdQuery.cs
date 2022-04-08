using Framework.Query;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.Inventories.Get
{
    public record GetInventoryByIdQuery(long Id,long SellerId) : IBaseQuery<InventoryDto>;
}