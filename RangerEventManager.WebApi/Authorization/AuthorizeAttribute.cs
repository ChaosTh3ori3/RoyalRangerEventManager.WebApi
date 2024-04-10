using Microsoft.AspNetCore.Mvc;

namespace RangerEventManager.WebApi.Authorization
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(PermissionItems item)
        : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { item };
        }
    }
}
