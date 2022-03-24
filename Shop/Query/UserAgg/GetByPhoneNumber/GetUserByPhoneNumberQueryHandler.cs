using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.GetByPhoneNumber
{
    public class GetUserByPhoneNumberQueryHandler : IBaseQueryHandler<GetUserByPhoneNumberQuery, UserDto>
    {
        private readonly ShopContext _context;

        public GetUserByPhoneNumberQueryHandler(ShopContext context) => _context = context;

        public async Task<UserDto> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.phoneNumber);
            if (user is null) return null;

            return user.MapSingle(_context);
        }
    }
}