using System;
namespace Application.Contract.UserAgg
{
	public class LoginResultDto
	{
        public string Token { get; private set; }
        public string RefreshToken { get; private set; }

		public LoginResultDto(string token ,string refreshToken)
		{
			Token = token;
			RefreshToken = refreshToken;
		}
	}
}