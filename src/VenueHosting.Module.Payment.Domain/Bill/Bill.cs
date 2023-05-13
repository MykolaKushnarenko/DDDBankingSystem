using VenueHosting.Module.Payment.Domain.Bill.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;
using VenueHosting.SharedKernel.Common.ValueObjects;

namespace VenueHosting.Module.Payment.Domain.Bill;

public sealed class Bill : AggregateRote<BillId, Guid>
{
    private Bill(){}

    private Bill(BillId id, VenueId venueId, AttendeeId attendeeId, LesseeId lesseeId, Price price, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        VenueId = venueId;
        AttendeeId = attendeeId;
        LesseeId = lesseeId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;

        // raise payed domain event
    }

    public VenueId VenueId { get; private set; }

    public AttendeeId AttendeeId { get; private set; }

    public LesseeId LesseeId { get; private set; }

    public Price Price { get; private set; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Bill Pay(VenueId venueId, AttendeeId attendeeId, LesseeId lesseeId, Price price)
    {
        return new Bill(BillId.CreateUnique(), venueId, attendeeId, lesseeId, price, DateTime.UtcNow, DateTime.UtcNow);
    }
}