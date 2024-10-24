using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.WebApi.Mapper.UserMapper;

public class UserMapper : IUserMapper
{
    public UserEntity MapIAMUserToUser(IAMUserEntity iamUser)
    {
        return new UserEntity()
        {
            Forname = iamUser.FirstName,
            Surename = iamUser.LastName,
            Mail = iamUser.Email,
            UserName = iamUser.Username
        };
    }
}