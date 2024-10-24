using RangerEventManager.Persistence.Entities.Base;

namespace RangerEventManager.Persistence.Entities.User;

public class UserEntity : BasePersonEntity
{
    public string UserName { get; set; }
}