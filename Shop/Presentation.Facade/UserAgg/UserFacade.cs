using Application.UserAgg.ChangePassword;
using Application.UserAgg.ChargeWallet;
using Application.UserAgg.Create;
using Application.UserAgg.Edit;
using Application.UserAgg.Register;
using Framework.Application;
using MediatR;
using Query.UserAgg.DTOs;
using Query.UserAgg.GetAll;
using Query.UserAgg.GetById;
using Query.UserAgg.GetByPhoneNumber;

namespace Presentation.Facade.UserAgg
{
    public class UserFacade : IUserFacade
	{
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> ChangePassword(ChangePasswordCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChargeWallet(ChargeWalletCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditUserCommand command) => await _mediator.Send(command);

        public async Task<UserFilterResult> GetAll(UserFilterParam filter) => await _mediator.Send(new GetAllUsersQuery(filter));

        public async Task<UserDto> GetBy(long id) => await _mediator.Send(new GetUserByIdQuery(id));

        public async Task<UserDto> GetBy(string phoneNumber) => await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));

        public async Task<OperationResult> Register(RegisterUserCommand command) => await _mediator.Send(command);
        
    }
}