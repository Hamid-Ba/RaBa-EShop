using Application.UserAgg.AddAddress;
using Application.UserAgg.DeleteAddress;
using Application.UserAgg.EditAddress;
using Framework.Application;
using MediatR;
using Query.UserAgg.DTOs;
using Query.UserAgg.UserAddresses.GetAll;

namespace Presentation.Facade.UserAgg.UserAddress
{
    public class UserAddressFacade : IUserAddressFacade
	{
        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Add(AddAddressCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Delete(DeleteAddressCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditAddressCommand command) => await _mediator.Send(command);

        public async Task<List<UserAddressDto>> GetAllBy(long userId) => await _mediator.Send(new GetAllUserAddressQuery(userId));
        
    }
}