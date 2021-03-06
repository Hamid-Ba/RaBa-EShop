using Application.UserAgg.Active;
using Application.UserAgg.AddToken;
using Application.UserAgg.ChangePassword;
using Application.UserAgg.ChargeWallet;
using Application.UserAgg.Create;
using Application.UserAgg.DeActive;
using Application.UserAgg.Edit;
using Application.UserAgg.Register;
using Application.UserAgg.RemoveToken;
using Application.UserAgg.UpdateToken;
using Framework.Application;
using Query.UserAgg.DTOs;

namespace Presentation.Facade.UserAgg
{
    public interface IUserFacade
	{
        #region Command
        Task<OperationResult> Edit(EditUserCommand command);
        Task<OperationResult> Active(ActiveUserCommand command);
        Task<OperationResult> Create(CreateUserCommand command);
        Task<OperationResult> AddToken(AddTokenCommand command);
        Task<OperationResult> DeActive(DeActiveUserCommand command);
        Task<OperationResult> Register(RegisterUserCommand command);
        Task<OperationResult> RemoveToken(RemoveTokenCommand command);
        Task<OperationResult> UpdateToken(UpdateTokenCommand command);
        Task<OperationResult> ChargeWallet(ChargeWalletCommand command);
        Task<OperationResult> ChangePassword(ChangePasswordCommand command);
        #endregion

        #region Query
        Task<UserDto> GetBy(long id);
        Task<UserDto> GetBy(string phoneNumber);
        Task<UserFilterResult> GetAll(UserFilterParam filter);
        Task<UserTokenDto> GetUserTokenByHashToken(string token);
        Task<UserTokenDto> GetUserTokenByRefreshToken(string refreshToken);
        #endregion
    }
}

