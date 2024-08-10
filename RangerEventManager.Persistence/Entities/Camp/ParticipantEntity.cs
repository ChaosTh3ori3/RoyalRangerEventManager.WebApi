using RangerEventManager.Persistence.Entities.Base;

namespace RangerEventManager.Persistence.Entities.Camp
{
    public class ParticipantEntity : PersonEntity
    {
        public bool CanSwim { get; set; }
        public IEnumerable<PersonEntity> ContactPersons { get; set; }
        public bool Paid { get; set; }
        public DateTime CreateDateTime { get; set; }
        public IEnumerable<AllergyEntity> Allergies { get; set; }
        public IEnumerable<DrugEntity> Drugs { get; set; }
    }
}
