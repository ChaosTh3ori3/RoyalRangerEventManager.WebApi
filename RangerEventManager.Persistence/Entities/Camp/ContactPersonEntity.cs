using RangerEventManager.Persistence.Entities.Base;

namespace RangerEventManager.Persistence.Entities.Camp;

public class ContactPersonEntity : BasePersonEntity
{
    internal long ParticipantId { get; set; } 
    internal ParticipantEntity Participant { get; set; }
}