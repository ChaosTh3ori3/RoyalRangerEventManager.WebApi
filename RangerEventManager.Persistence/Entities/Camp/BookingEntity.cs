namespace RangerEventManager.Persistence.Entities.Camp;

public class BookingEntity
{
    public long BookingId { get; set; }
    public string Name { get; set; }
    public double Amount { get; set; }
    public DateTime BookingDate { get; set; }
    public string BankAccount { get; set; }
    public string Description { get; set; }
    
    internal long? IncommingFinanceId { get; set; }
    internal FinanceEntity IncommingFinance { get; set; }
    internal long? OutgoingFinanceId { get; set; }
    internal FinanceEntity OutgoingFinance { get; set; }
}