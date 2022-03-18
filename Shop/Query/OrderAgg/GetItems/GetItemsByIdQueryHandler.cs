using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.OrderAgg.DTOs;

namespace Query.OrderAgg.GetItems
{
    public class GetItemsByIdQueryHandler : IBaseQueryHandler<GetItemsByIdQuery, List<OrderItemDto>>
    {
        private readonly ShopContext _context;

        public GetItemsByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<List<OrderItemDto>> Handle(GetItemsByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);
            if (order is null) return null;

            return order.Items.MapItems(_context);
        }
    }
}