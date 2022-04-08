using Framework.Query;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.Inventories.GetAll
{
    public record GetInventoriesBySellerIdQuery(long SellerId) : IBaseQuery<List<InventoryDto>>;
}