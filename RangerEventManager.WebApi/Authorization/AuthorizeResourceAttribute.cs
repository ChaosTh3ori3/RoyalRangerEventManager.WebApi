using Microsoft.AspNetCore.Mvc;

namespace RangerEventManager.WebApi.Authorization
{
    public class AuthorizeResourceAttribute : TypeFilterAttribute
    {
        public AuthorizeResourceAttribute(PermissionItems item)
        : base(typeof(AuthorizeActionFilter))
        {
            Arguments = [item];
        }
    }
}
