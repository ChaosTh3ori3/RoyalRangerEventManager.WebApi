using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.Persistence.Entities.Camp;

public class TaskEntity
{
    public long TaskId { get; set; }
    public string Name { get; set; }
    internal long ResponsiblePersonId { get; set; }
    public UserEntity ResponsiblePerson { get; set; }
    public string Description { get; set; }
    public DateTime ToBeDoneDateTime { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneDateTime { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}