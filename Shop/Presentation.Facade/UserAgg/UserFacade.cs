using Application.UserAgg.Active;
using Application.UserAgg.AddToken;
using Application.UserAgg.ChangePassword;
using Application.UserAgg.ChargeWallet;
using Application.UserAgg.Create;
using Application.UserAgg.DeActive;
using Application.UserAgg.Edit;
using Application.UserAgg.Register;
using Application.UserAgg.UpdateToken;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using MediatR;
using Query.UserAgg.DTOs;
using Query.UserAgg.GetAll;
using Query.UserAgg.GetById;
using Query.UserAgg.GetByPhoneNumber;
using Query.UserAgg.UserTokens.GetByRefreshToken;

namespace Presentation.Facade.UserAgg
{
    public class UserFacade : IUserFacade
	{
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Active(ActiveUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> AddToken(AddTokenCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChangePassword(ChangePasswordCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChargeWallet(ChargeWalletCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> DeActive(DeActiveUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditUserCommand command) => await _mediator.Send(command);

        public async Task<UserFilterResult> GetAll(UserFilterParam filter) => await _mediator.Send(new GetAllUsersQuery(filter));

        public async Task<UserDto> GetBy(long id) => await _mediator.Send(new GetUserByIdQuery(id));

        public async Task<UserDto> GetBy(string phoneNumber) => await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));

        public async Task<UserTokenDto> GetTokenBy(string refreshToken)
        {
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }

        public async Task<OperationResult> Register(RegisterUserCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> UpdateToken(UpdateTokenCommand command) => await _mediator.Send(command);
    }
}