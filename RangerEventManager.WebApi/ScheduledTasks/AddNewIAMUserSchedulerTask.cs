using RangerEventManager.WebApi.Mapper.UserMapper;
using RangerEventManager.WebApi.Repositories;
using RangerEventManager.WebApi.ScheduledTasks.Base;
using RangerEventManager.WebApi.Services.IAMService;
using RangerEventManager.WebApi.Services.UserService;

namespace RangerEventManager.WebApi.ScheduledTasks;

public class AddNewIAMUserSchedulerTask(
    IIAMService iamService,
    IUserService userService,
    IUserRepository userRepository,
    IUserMapper userMapper) : IScheduledTask
{
    public async Task ExecuteAsync()
    {
        var accessToken = await iamService.GetAccessToken();
        if (accessToken != null)
        {
            var iamUsers = await iamService.GetAllUsers(accessToken);
            if (iamUsers.Any())
            {
                var allInternalUsers = await userService.GetAllUsers();
                var allInternalUserNames = allInternalUsers.Select(u => u.UserName).ToList();
                
                var newIamUsernames = iamUsers
                    .Where(iamu => !allInternalUserNames.Contains(iamu.Username))
                    .ToList();
                
                if (newIamUsernames.Any())
                {
                    var newIamUsers = iamUsers
                        .Where(u => newIamUsernames.Any(iamu => iamu.Username == u.Username))
                        .ToList();
                    
                    var mappedUsers = newIamUsers
                        .Select(userMapper.MapIAMUserToUser)
                        .ToList();
                    
                    foreach (var mappedUser in mappedUsers)
                    {
                        await userRepository.AddUser(mappedUser);
                    }
                }
            }
        }
    }
}