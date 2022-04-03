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

        public UserToken(string hashToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            Guard(hashToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            HashToken = hashToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
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