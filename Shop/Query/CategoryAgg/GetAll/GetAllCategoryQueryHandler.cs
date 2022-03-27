using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg.GetAll
{
    public class GetAllCategoryQueryHandler : IBaseQueryHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetAllCategoryQueryHandler(ShopContext context) => _context = context;

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.Where(c => c.ParentId == null)
                .Include(c => c.Children)
                .ThenInclude(c => c.Children)
                .OrderByDescending(o => o.Id).ToListAsync();
            return categories.Map();
        }
    }
}