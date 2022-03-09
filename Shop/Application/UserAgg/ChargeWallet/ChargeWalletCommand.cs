using Framework.Application;

namespace Application.UserAgg.ChargeWallet
{
    public record ChargeWalletCommand(long UserId,double Amount) : IBaseCommand;
}