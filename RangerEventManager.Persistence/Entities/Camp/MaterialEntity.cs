using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.Persistence.Entities.Camp;

public class MaterialEntity
{
    public long MaterialId { get; set; }
    public string Name { get; set; }
    internal long ResponsiblePersonId { get; set; }
    public UserEntity ResponsiblePerson { get; set; }
    public int TroopNumber { get; set; }
    public string TroopName { get; set; }
    public string Description { get; set; }
    public string PlaceToUse { get; set; }
    public int Amount { get; set; }
    public string AmountUnit { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}