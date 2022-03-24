using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.GetAll
{
    public class GetAllSellerQueryHandler : IBaseQueryHandler<GetAllSellerQuery, SellerFilterResult>
    {
        private readonly ShopContext _context;

        public GetAllSellerQueryHandler(ShopContext context) => _context = context;

        public async Task<SellerFilterResult> Handle(GetAllSellerQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var sellers = _context.Sellers.OrderByDescending(o => o.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.ShopName))
                sellers = sellers.Where(s => s.ShopName.Contains(@params.ShopName));

            if (!string.IsNullOrWhiteSpace(@params.NationalCode))
                sellers = sellers.Where(s => s.NationalCode.Contains(@params.NationalCode));

            var skip = (@params.PageId - 1) * @params.Take;

            var result = new SellerFilterResult(sellers.Skip(skip).Take(@params.Take).Select(s => s.Map(_context)).ToList(), @params);

            result.GeneratePaging(sellers, @params.Take, @params.PageId);

            return result;
        }
    }
}