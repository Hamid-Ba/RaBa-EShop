using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetBySlug
{
    public class GetProductBySlugQueryHandler : IBaseQueryHandler<GetProductBySlugQuery, ProductDto>
    {
        private readonly ShopContext _context;

        public GetProductBySlugQueryHandler(ShopContext context) => _context = context;

        public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Slug == request.Slug);
            if (product is null) return null;

            return product.MapSingle(_context);
        }
    }
}