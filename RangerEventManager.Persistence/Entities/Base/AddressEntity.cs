namespace RangerEventManager.Persistence.Entities.Base
{
    public class AddressEntity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; } = "DE";
    }
}
