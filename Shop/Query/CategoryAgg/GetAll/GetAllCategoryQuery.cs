using Framework.Query;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg.GetAll
{
    public record GetAllCategoryQuery : IBaseQuery<List<CategoryDto>>;
}