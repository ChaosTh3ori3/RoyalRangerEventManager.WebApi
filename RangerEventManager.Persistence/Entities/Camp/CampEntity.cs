using System.ComponentModel.DataAnnotations.Schema;
using RangerEventManager.Persistence.Entities.Base;
using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.Persistence.Entities.Camp;
public class CampEntity
{
    public long CampId { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public long Number { get; set; }
    public string Name { get; set; }
    public string Concept { get; set; }
    public DateTime StatDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime? PreCampStartDate { get; set; }
    public DateTime? PreCampEndDate { get; set; }
    public DateTime? AfterCampStartDate { get; set; }
    public DateTime? AfterCampEndDate { get; set; }
    public bool Archived { get; set; }
    public List<UserEntity> Leaders { get; set; }
    public List<UserEntity>? Employees { get; set; }
    public List<ParticipantEntity>? Participants { get; set; } 
    public LocationEntity? Location { get; set; }
    public List<DeadlineEntity>? Deadlines { get; set; }
    public List<TaskEntity>? Tasks { get; set; }
    public List<EventEntity>? Events { get; set; }
    public List<FileEntity>? Files { get; set; }
    public List<MaterialEntity>? Materials { get; set; }
    public FinanceEntity? Finance { get; set; }
    public RegistrationEntity? Registration { get; set; }
}
