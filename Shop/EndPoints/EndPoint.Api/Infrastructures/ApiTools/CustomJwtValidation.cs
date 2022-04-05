using Framework.Presentation.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Presentation.Facade.UserAgg;

namespace EndPoint.Api.Infrastructures.ApiTools
{
    public class CustomJwtValidation
    {
        private readonly IUserFacade _userFacade;

        public CustomJwtValidation(IUserFacade userFacade) => _userFacade = userFacade;

        public async Task Validation(TokenValidatedContext context)
        {
            var userId = context.Principal.GetUserId();
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var userToken = await _userFacade.GetUserTokenByHashToken(token);
            if (userToken is null)
            {
                context.Fail("Token Not Found");
                return;
            }

            var user = await _userFacade.GetBy(userId);
            if (user is null || !user.IsActive)
            {
                context.Fail("User DeActive");
                return;
            }

        }
    }
}