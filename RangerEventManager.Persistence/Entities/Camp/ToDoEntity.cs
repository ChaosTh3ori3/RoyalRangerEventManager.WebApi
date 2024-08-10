namespace RangerEventManager.Persistence.Entities.Camp
{
    public class ToDoEntity
    {
        public string Name { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Description { get; set; }
        public DateTime LatestProcessingDateTime { get; set; }
        public bool IsDone { get; set; }
    }
}
