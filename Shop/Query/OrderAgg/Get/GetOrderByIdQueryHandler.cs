using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.OrderAgg.DTOs;

namespace Query.OrderAgg.Get
{
    public class GetOrderByIdQueryHandler : IBaseQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly ShopContext _context;

        public GetOrderByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);
            if (order is null) return null;

            return order.Map(_context);
        }
    }
}