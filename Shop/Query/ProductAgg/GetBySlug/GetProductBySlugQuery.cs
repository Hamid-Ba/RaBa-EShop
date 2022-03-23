using Framework.Query;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetBySlug
{
    public record GetProductBySlugQuery(string Slug) : IBaseQuery<ProductDto>;
}