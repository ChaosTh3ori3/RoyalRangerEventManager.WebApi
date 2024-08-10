using RangerEventManager.Persistence.Enums;

namespace RangerEventManager.Persistence.Entities.Camp
{
    public class AllergyEntity
    {
        public string Name { get; set; }
        public AllergyIntensity Intensity { get; set; }
    }
}
