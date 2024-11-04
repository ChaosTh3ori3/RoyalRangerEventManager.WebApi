using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace RangerEventManager.WebApi.Authorization
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly PermissionItems _item;
        public AuthorizeActionFilter(PermissionItems item)
        {
            _item = item;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var resourceAccess = context.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "resource_access");
            var resources = JsonSerializer.Deserialize<ResourceAccess>(resourceAccess.Value);

            var roles = resources.RremApi.Roles;

            var isAuthorized = roles.Any(role => role == _item.ToString());

            if (!isAuthorized)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
