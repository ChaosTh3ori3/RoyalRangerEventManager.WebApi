using Microsoft.Extensions.Options;
using RangerEventManager.Persistence.Entities.User;
using RangerEventManager.Persistence.Settings;
using RangerEventManager.WebApi.Repositories;

namespace RangerEventManager.WebApi.Services.UserService
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public string GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await userRepository.GetUsers();
        }
    }
}
