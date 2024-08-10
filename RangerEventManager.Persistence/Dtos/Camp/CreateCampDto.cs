namespace RangerEventManager.Persistence.Dtos.Camp
{
    public class CreateCampDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstimatedParticipantQuantity { get; set; }
        public IEnumerable<string> LeaderUsers { get; set; }
        public IEnumerable<string> MemberUsers { get; set; }
        public DateTime MainStartDate { get; set; }
        public DateTime MainEndDate { get; set; }
        public DateTime PreCampStartDate { get; set; }
        public DateTime PreCampEndDate { get; set; }
        public DateTime PostCampStartDate { get; set; }
        public DateTime PostCampEndDate { get; set; }
    }
}
