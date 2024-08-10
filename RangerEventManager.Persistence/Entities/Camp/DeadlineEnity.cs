namespace RangerEventManager.Persistence.Entities.Camp
{
    public class DeadlineEnity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadlineDateTime { get; set; }
        public bool IsExpired { get; set; }
    }
}
