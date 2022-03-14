using Domain.OrderAgg;
using Domain.OrderAgg.Repository;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistent.EfCore.OrderAgg
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ShopContext _context;

        public OrderRepository(ShopContext context) : base(context) => _context = context;

        public Task<Order> GetUserOpenOrderBy(long userId) => _context.Orders.FirstOrDefaultAsync(o => o.UserId == userId);

    }
}