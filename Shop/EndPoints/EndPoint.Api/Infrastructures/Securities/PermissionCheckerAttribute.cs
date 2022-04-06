using Domain.RoleAgg.Enums;
using Framework.Presentation.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.Facade.RoleAgg;
using Presentation.Facade.UserAgg;

namespace EndPoint.Api.Infrastructures.Securities
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private IUserFacade _userFacade;
        private IRoleFacade _roleFacade;
        private readonly Permission permissionId;

        public PermissionCheckerAttribute(Permission permissionId) => this.permissionId = permissionId;

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (HasAllowAnonymous(context))
                return;

            _userFacade = context.HttpContext.RequestServices.GetRequiredService<IUserFacade>();
            _roleFacade = context.HttpContext.RequestServices.GetRequiredService<IRoleFacade>();

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!(await IsUserHasPermission(context))) { context.Result = new ForbidResult(); }
            }
            else context.Result = new UnauthorizedObjectResult("Please Login");
        }

        private async Task<bool> IsUserHasPermission(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.User.GetUserId();
            var user = await _userFacade.GetBy(userId);
            if (user is null) return false;

            var userRolesId = user.Roles.Select(r => r.RoleId).ToList();

            foreach (var userRoleId in userRolesId)
                if (await IsRoleHasPermission(userRoleId)) return true;

            return false;
        }

        private async Task<bool> IsRoleHasPermission(long roleId)
        {
            var role = await _roleFacade.GetBy(roleId);
            return role.Permissions.Any(p => p == permissionId);
        }

        private bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
            bool hasAllowAnonymous = false;
            foreach (var f in metaData)
            {
                try
                {
                    hasAllowAnonymous = f.TypeId.Name == "AllowAnonymousAttribute";
                    if (hasAllowAnonymous)
                        break;
                }
                catch
                {
                    // ignored
                }
            }

            return hasAllowAnonymous;
        }
    }
}