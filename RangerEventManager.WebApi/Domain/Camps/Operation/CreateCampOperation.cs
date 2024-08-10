using RangerEventManager.Persistence.Enums;

namespace RangerEventManager.WebApi.Domain.Camps.Operation
{
    public class CreateCampOperation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstimatedParticipantQuantity { get; set; }
        public string CreateUser { get; set; }
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
