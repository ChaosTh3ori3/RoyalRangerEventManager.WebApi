using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.Persistence.Entities.Camp;

public class DeadlineEntity
{
    public long DeadlineId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime ExpiredDateTime { get; set; }
    internal long ResponsiblePersonId { get; set; }
    public UserEntity ResponsiblePerson { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}