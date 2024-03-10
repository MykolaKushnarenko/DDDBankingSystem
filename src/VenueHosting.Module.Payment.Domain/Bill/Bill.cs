using Component.Domain.Models;
using Component.Domain.ValueObjects;
using VenueHosting.Module.Payment.Domain.Bill.ValueObjects;

namespace VenueHosting.Module.Payment.Domain.Bill;

public sealed class Bill : AggregateRote<Bill>
{
    private Bill(){}

    private Bill(Id<Bill> id, VenueId venueId, AttendeeId attendeeId, LesseeId lesseeId, Price price, DateTime createdDateTime,
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
        return new Bill(Id<Bill>.CreateUnique(), venueId, attendeeId, lesseeId, price, DateTime.UtcNow, DateTime.UtcNow);
    }
}