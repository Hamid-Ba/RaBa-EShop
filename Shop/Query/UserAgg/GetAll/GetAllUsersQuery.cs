using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.GetAll
{
    public class GetAllUsersQuery : QueryFilter<UserFilterResult, UserFilterParam>
    {
        public GetAllUsersQuery(UserFilterParam filterParams) : base(filterParams)
        {
        }
    }
}