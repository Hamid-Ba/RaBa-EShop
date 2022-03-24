using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.GetById
{
    public class GetUserByIdQueryHandler : IBaseQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly ShopContext _context;

        public GetUserByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            if (user is null) return null;

            return user.MapSingle(_context);
        }
    }
}