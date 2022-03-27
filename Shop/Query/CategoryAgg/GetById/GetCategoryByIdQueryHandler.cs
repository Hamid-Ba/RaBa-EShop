using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg.GetById
{
    public class GetCategoryByIdQueryHandler : IBaseQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ShopContext _context;

        public GetCategoryByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Include(c => c.Children)
                .ThenInclude(c => c.Children)
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            return category.Map();
        }
    }
}