using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetById
{
    public class GetProductByIdQueryHandler : IBaseQueryHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly ShopContext _context;

        public GetProductByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product is null) return null;

            return product.MapSingle(_context);
        }
    }
}