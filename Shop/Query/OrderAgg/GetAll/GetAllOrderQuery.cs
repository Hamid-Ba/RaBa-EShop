using Framework.Query;
using Infrastructure.Persistent.Dapper;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.OrderAgg.DTOs;

namespace Query.OrderAgg.GetAll
{
    public class GetAllOrderQuery : QueryFilter<OrderFilterResult, OrderFilterParam>
    {
        public GetAllOrderQuery(OrderFilterParam filterParams) : base(filterParams)
        {
        }
    }

    public class GetAllOrderQueryHandler : IBaseQueryHandler<GetAllOrderQuery, OrderFilterResult>
    {
        private readonly ShopContext _context;
        private readonly DapperContext _dapperContext;

        public GetAllOrderQueryHandler(ShopContext context,DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        } 

        public async Task<OrderFilterResult> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var orders = _context.Orders.OrderByDescending(o => o.Id).AsQueryable();

            #region Filters

            if (@params.UserId != 0)
                orders = orders.Where(c => c.UserId == @params.UserId);

            if (@params.StartDate != null)
                orders = orders.Where(c => c.CreationDate >= @params.StartDate);

            if (@params.EndDate != null)
                orders = orders.Where(c => c.CreationDate <= @params.EndDate);

            if (@params.Status != null)
                orders = orders.Where(c => c.Status == @params.Status);

            #endregion

            var ordersList = await orders.Skip((@params.PageId - 1) * @params.Take).ToListAsync();

            var result = new OrderFilterResult(ordersList.Map(_context), @params);

            return result;
        }
    }
}

