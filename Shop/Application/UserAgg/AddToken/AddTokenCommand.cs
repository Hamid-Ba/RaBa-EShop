using Framework.Application;

namespace Application.UserAgg.AddToken
{
    public record AddTokenCommand(long UserId, string HashToken, string HashRefreshToken, DateTime TokenExpireDate,
        DateTime RefreshTokenExpireDate, string Device) : IBaseCommand;
}