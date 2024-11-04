using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.WebApi.Services.UserService
{
    public interface IUserService
    {
        public string GetCurrentUserFromHttpContext(HttpContext context);
        public Task<List<UserEntity>> GetAllUsers();
    }
}
