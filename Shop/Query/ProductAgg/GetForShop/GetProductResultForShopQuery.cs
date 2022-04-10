using Framework.Query;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg.GetForShop
{
    public class GetProductResultForShopQuery : QueryFilter<ProductShopResultDto, ProductShopFilterParam>
    {
        public GetProductResultForShopQuery(ProductShopFilterParam filterParams) : base(filterParams)
        {
        }
    }
}