using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.Persistence.Entities.Camp;

public class EventEntity
{
    public long EventId { get; set; }
    public string Name { get; set; }
    internal long ResponsiblePersonId { get; set; }
    public UserEntity ResponsiblePerson { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}