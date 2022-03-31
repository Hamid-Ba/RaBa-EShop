using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.AddAddress
{
    public class AddAddressCommandHandler : IBaseCommandHandler<AddAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddAddressCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            var address = new UserAddress(request.FullName, request.PhoneNumber, request.Province, request.City,
                request.Address, request.PostalCode, request.NationalCode);
            user.AddAddress(address);

            await _userRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}