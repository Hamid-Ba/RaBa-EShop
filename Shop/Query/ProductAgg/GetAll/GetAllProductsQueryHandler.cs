using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetAll
{
    public class GetAllProductsQueryHandler : IBaseQueryHandler<GetAllProductsQuery, ProductFilterResult>
    {
        private readonly ShopContext _context;

        public GetAllProductsQueryHandler(ShopContext context) => _context = context;

        public async Task<ProductFilterResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.Title))
                products = products.Where(p => p.Title.Contains(@params.Title));

            if (!string.IsNullOrWhiteSpace(@params.Slug))
                products = products.Where(p => p.Slug == @params.Slug);

            var result = new ProductFilterResult(await products.Skip((@params.PageId - 1) * @params.Take).Take(@params.Take)
                .Select(p => p.Map(_context)).ToListAsync(), @params);

            result.GeneratePaging(products, @params.Take, @params.PageId);

            return result;
        }
    }
}