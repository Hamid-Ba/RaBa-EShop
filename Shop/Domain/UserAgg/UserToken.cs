using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.UserAgg
{
    public class UserToken : BaseEntity
	{
        public long UserId { get;internal set; }
        public string HashToken { get; private set; }
        public string HashRefreshToken { get; private set; }
        public DateTime TokenExpireDate { get; private set; }
        public DateTime RefreshTokenExpireDate { get; private set; }
        public string Device { get; private set; }

        private UserToken() { }

        public UserToken(string hashToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            Guard(hashToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            HashToken = hashToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }

        public void UpdateToken(string newHashToken,string newHashRefreshToken, DateTime newTokenExpireDate, DateTime newRefreshTokenExpireDate)
        {
            if (TokenExpireDate >= DateTime.Now)
                throw new InvalidDataException("Token Is Still Valid");

            if(RefreshTokenExpireDate < DateTime.Now)
                throw new InvalidDataException("Refresh Token Is Not Valid Anymore");

            HashToken = newHashToken;
            HashRefreshToken = newHashRefreshToken;

            TokenExpireDate = newTokenExpireDate;
            RefreshTokenExpireDate = newRefreshTokenExpireDate;
        }

        private void Guard(string hashToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            NullOrEmptyDomainDataException.CheckString(hashToken, nameof(hashToken));
            NullOrEmptyDomainDataException.CheckString(hashRefreshToken, nameof(hashRefreshToken));

            if (tokenExpireDate < DateTime.Now)
                throw new InvalidDataException("Invalid Token Expire Date");

            if (refreshTokenExpireDate < tokenExpireDate)
                throw new InvalidDataException("Invalid Refresh Token Expire Date");
        }
    }
}