using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.DeleteAddress
{
    public class DeleteAddressCommandHandler : IBaseCommandHandler<DeleteAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteAddressCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetEntityAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            user.DeleteAddress(request.AddressId);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}