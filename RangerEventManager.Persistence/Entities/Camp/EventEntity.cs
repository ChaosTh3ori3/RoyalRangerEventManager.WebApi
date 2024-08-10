namespace RangerEventManager.Persistence.Entities.Camp
{
    public class EventEntity
    {
        public string Name { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
