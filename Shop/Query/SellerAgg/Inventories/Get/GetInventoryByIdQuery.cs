using Framework.Query;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.Inventories.Get
{
    public record GetInventoryByIdQuery(long Id) : IBaseQuery<InventoryDto>;
}