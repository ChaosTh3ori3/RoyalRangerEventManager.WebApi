namespace RangerEventManager.WebApi.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
    
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUser()
        {
            var principal = httpContextAccessor.HttpContext?.User;

            if (principal != null)
            {
                var userId = principal.Claims.FirstOrDefault(claim => claim.Type == "preferred_username")?.Value;
                if (userId != null)
                {
                    return userId;
                }
            }

            return "System";
        }
    }
}
