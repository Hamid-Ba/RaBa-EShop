using Framework.Query;
using Query.OrderAgg.DTOs;

namespace Query.OrderAgg.GetItems
{
    public record GetItemsByIdQuery(long OrderId) : IBaseQuery<List<OrderItemDto>>;
}