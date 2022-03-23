using Framework.Query;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetAll
{
    public class GetAllProductsQuery : QueryFilter<ProductFilterResult, ProductFilterParam>
    {
        public GetAllProductsQuery(ProductFilterParam filterParams) : base(filterParams)
        {
        }
    }
}