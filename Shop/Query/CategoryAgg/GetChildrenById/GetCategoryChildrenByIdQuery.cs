using Framework.Query;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg.GetChildrenById
{
    public record GetCategoryChildrenByIdQuery(long ParentId) : IBaseQuery<List<CategoryDto>>;
}