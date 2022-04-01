using Domain.UserAgg.Repository;
using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserAddresses.GetAll
{
    public class GetAllUserAddressQueryHandler : IBaseQueryHandler<GetAllUserAddressQuery, List<UserAddressDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserAddressQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<List<UserAddressDto>> Handle(GetAllUserAddressQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return null;

            return user.Addresses.Select(a => a.MapAddress()).ToList();
        }
    }
}

