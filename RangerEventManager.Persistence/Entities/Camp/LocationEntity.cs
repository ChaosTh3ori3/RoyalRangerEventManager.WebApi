namespace RangerEventManager.Persistence.Entities.Camp;
public class LocationEntity 
{
    public long LocationId { get; set; }
    public string Name  { get; set; }
    public string Link { get; set; }
    public double Longitude { get; set; }
    public double Laditude { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}
