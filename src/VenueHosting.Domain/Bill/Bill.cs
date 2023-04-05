using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Bill.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Common.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;
using VenueHosting.Domain.VenueDomain.Lessee.ValueObjects;

namespace VenueHosting.Domain.Bill;

public sealed class Bill : AggregateRote<BillId>
{
    private Bill(BillId id, VenueId venueId, AttendeeId attendeeId, LesseeId lesseeId, Price price, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        VenueId = venueId;
        AttendeeId = attendeeId;
        LesseeId = lesseeId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public VenueId VenueId { get; private set; }

    public AttendeeId AttendeeId { get; private set; }

    public LesseeId LesseeId { get; private set; }

    public Price Price { get; private set; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Bill Create(VenueId venueId, AttendeeId attendeeId, LesseeId lesseeId, Price price)
    {
        return new Bill(BillId.CreateUnique(), venueId, attendeeId, lesseeId, price, DateTime.UtcNow, DateTime.UtcNow);
    }
}