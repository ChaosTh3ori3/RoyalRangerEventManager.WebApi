using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.Persistence.Enums;

namespace RangerEventManager.Persistence.Dtos.Camp
{
    public class ReadCampDto
    {
        public long Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Arcived { get; set; }
        public CampCategoriesEnum Categoty { get; set; }
        public IEnumerable<string> LeaderUsers { get; set; }
        public IEnumerable<string> MemberUsers { get; set; }
        public IEnumerable<ParticipantEntity> Participants { get; set; }
        public IEnumerable<MaterialEntity> Materials { get; set; }
        public IEnumerable<EventEntity> Events { get; set; }
        public IEnumerable<ToDoEntity> ToDos { get; set; }
        public IEnumerable<DeadlineEnity> Deadlines { get; set; }
        public DateTime MainStartDate { get; set; }
        public DateTime MainEndDate { get; set; }
        public DateTime PreCampStartDate { get; set; }
        public DateTime PreCampEndDate { get; set; }
        public DateTime PostCampStartDate { get; set; }
        public DateTime PostCampEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastChangeDate { get; set; }

    }
}
