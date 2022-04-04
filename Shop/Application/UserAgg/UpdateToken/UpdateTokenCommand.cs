using Framework.Application;

namespace Application.UserAgg.UpdateToken
{
    public class UpdateTokenCommand : IBaseCommand
	{
        public long UserId { get; set; }
        public long TokenId { get; set; }
        public string NewHashToken { get; private set; }
        public string NewHashRefreshToken { get; private set; }
        public DateTime NewTokenExpireDate { get; private set; }
        public DateTime NewRefreshTokenExpireDate { get; private set; }

        public UpdateTokenCommand(long tokenId,string hashToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate)
        {
            TokenId = tokenId;
            NewHashToken = hashToken;
            NewHashRefreshToken = hashRefreshToken;
            NewTokenExpireDate = tokenExpireDate;
            NewRefreshTokenExpireDate = refreshTokenExpireDate;
        }
    }
}