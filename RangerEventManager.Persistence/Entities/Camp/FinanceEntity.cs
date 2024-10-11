using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.Persistence.Entities.Camp;

public class FinanceEntity
{
    public long FinanceId { get; set; }
    internal long ResponsiblePersonId { get; set; }
    public UserEntity ResponsiblePerson { get; set; }
    public List<BookingEntity> IncommingBookings { get; set; }
    public List<BookingEntity> OutgoingBookings { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}