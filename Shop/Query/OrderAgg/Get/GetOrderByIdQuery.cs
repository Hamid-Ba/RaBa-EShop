using Framework.Query;
using Query.OrderAgg.DTOs;

namespace Query.OrderAgg.Get
{
    public record GetOrderByIdQuery(long OrderId) : IBaseQuery<OrderDto>;
}