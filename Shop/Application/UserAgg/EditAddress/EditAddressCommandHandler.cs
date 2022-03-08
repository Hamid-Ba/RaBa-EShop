using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.EditAddress
{
    public class EditAddressCommandHandler : IBaseCommandHandler<EditAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditAddressCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(EditAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetEntityAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            var newAddress = new UserAddress(request.FullName, request.PhoneNumber, request.Province, request.City,
                request.Address, request.PostalCode, request.NationalCode);
            user.EditAddress(request.AddressId, newAddress);

            await _userRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}

