using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.WebApi.Services.UserService
{
    public interface IUserService
    {
        public string GetCurrentUser();
        public Task<List<UserEntity>> GetAllUsers();
    }
}
