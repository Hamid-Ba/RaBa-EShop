using Domain.UserAgg.Repository;
using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserAddresses.GetBy
{
    public class GetUserAddressByIdQueryHandler : IBaseQueryHandler<GetUserAddressByIdQuery, UserAddressDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserAddressByIdQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<UserAddressDto> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return new UserAddressDto();

            return user.Addresses.FirstOrDefault(a => a.Id == request.Id).MapAddress();
        }
    }
}