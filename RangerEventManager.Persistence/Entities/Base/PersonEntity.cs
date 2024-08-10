namespace RangerEventManager.Persistence.Entities.Base
{
    public class PersonEntity
    {
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Surename { get; set; }
        public string Forname { get; set; }
        public int TroopNumber { get; set; }
        public string TroopName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumer { get; set; }
        public string MobilePhoneNumer { get; set; }
        public AddressEntity Address { get; set; }
    }
}
