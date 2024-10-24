using Microsoft.EntityFrameworkCore;
using RangerEventManager.Persistence;
using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.WebApi.Repositories;

public class UserRepository(IServiceProvider serviceProvider) : BaseRepository(serviceProvider), IUserRepository
{
    public Task<UserEntity> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserEntity>> GetUsers()
    {
        return await Context.Users.ToListAsync();
    }

    public async Task AddUser(UserEntity user)
    {
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();
    }
}