using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg.GetChildrenById
{
    public class GetCategoryChildrenByIdQueryHandler : IBaseQueryHandler<GetCategoryChildrenByIdQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryChildrenByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<List<CategoryDto>> Handle(GetCategoryChildrenByIdQuery request, CancellationToken cancellationToken)
        {
            var children = await _context.Categories.Where(c => c.ParentId == request.ParentId).Include(c => c.Children).ToListAsync();
            return children.Map();
        }
    }
}