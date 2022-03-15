using Framework.Query;
using Query.CategoryAgg.DTOs;

namespace Query.CategoryAgg.GetById
{
    public record GetCategoryByIdQuery(long Id) : IBaseQuery<CategoryDto>;
}