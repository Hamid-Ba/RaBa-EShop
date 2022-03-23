using Framework.Query;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetById
{
    public record GetProductByIdQuery(long Id) : IBaseQuery<ProductDto>;
}