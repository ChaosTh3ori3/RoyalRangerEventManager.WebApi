using System.Collections.Generic;
using System.Threading.Tasks;
using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.WebApi.Services.IAMService;

public interface IIAMService
{
    public Task<string?> GetAccessToken();
    public Task<List<IAMUserEntity>> GetAllUsers(string accessToken);
    public Task AddUser(object user, string accessToken);
}