using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.WebApi.Mapper.UserMapper;

public interface IUserMapper
{
    UserEntity MapIAMUserToUser(IAMUserEntity iamUser);
}