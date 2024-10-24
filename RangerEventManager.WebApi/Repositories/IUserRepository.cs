using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.WebApi.Repositories;

public interface IUserRepository
{
    public Task<UserEntity> GetUserByEmail(string email);
    public Task<UserEntity> GetUserById(int id);
    public Task<List<UserEntity>> GetUsers();
    public Task AddUser(UserEntity user);
}