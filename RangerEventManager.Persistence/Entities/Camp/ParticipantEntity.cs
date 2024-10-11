using System.ComponentModel.DataAnnotations;
using RangerEventManager.Persistence.Entities.Base;

namespace RangerEventManager.Persistence.Entities.Camp;

public class ParticipantEntity : BasePersonEntity
{
    public List<ContactPersonEntity> ContactPersons { get; set; }
    public bool ContributionPaid { get; set; }
    public DateTime? ContributionPaidDate { get; set; }
    public List<PeculiarityEntity> Peculiarities { get; set; }
    public bool CanSwim { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}