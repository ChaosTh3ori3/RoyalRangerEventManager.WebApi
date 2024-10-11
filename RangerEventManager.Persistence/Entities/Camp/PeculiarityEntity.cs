namespace RangerEventManager.Persistence.Entities.Camp;

public class PeculiarityEntity
{
    public long PeculiarityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime ToBeDoneDate { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneDate { get; set; }
    
    internal long ParticipantId { get; set; }
    internal ParticipantEntity Participant { get; set; }
}