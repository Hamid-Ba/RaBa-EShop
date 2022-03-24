using Framework.Query;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.GetAll
{
    public class GetAllSellerQuery : QueryFilter<SellerFilterResult, SellerFilterParam>
    {
        public GetAllSellerQuery(SellerFilterParam filterParams) : base(filterParams)
        {
        }
    }
}