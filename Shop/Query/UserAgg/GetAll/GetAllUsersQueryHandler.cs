using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.GetAll
{
    public class GetAllUsersQueryHandler : IBaseQueryHandler<GetAllUsersQuery, UserFilterResult>
    {
        private readonly ShopContext _context;

        public GetAllUsersQueryHandler(ShopContext context) => _context = context;

        public async Task<UserFilterResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var users = _context.Users.OrderByDescending(o => o.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(@params.Email))
                users = users.Where(u => u.Email.Contains(@params.Email));

            if (!string.IsNullOrWhiteSpace(@params.PhoneNumber))
                users = users.Where(u => u.PhoneNumber.Contains(@params.PhoneNumber));

            var skip = (@params.PageId - 1) * @params.Take;

            var result = new UserFilterResult
            {
                FilterParams = @params,
                Data = await users.Skip(skip).Take(@params.Take).Select(u => u.Map(_context)).ToListAsync()
            };

            //var list = await users.Skip(skip).Take(@params.Take).ToListAsync();

            //var result = new UserFilterResult(list.MapList(_context), @params);

            result.GeneratePaging(users, @params.Take, @params.PageId);

            return result;
        }
    }
}