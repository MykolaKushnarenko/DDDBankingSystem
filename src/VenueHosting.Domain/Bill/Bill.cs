using VenueHosting.Domain.Bill.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Common.ValueObjects;
using VenueHosting.Domain.Dinner.ValueObjects;
using VenueHosting.Domain.Guest.ValueObjects;
using VenueHosting.Domain.Host.ValueObjects;

namespace VenueHosting.Domain.Bill;

public sealed class Bill : AggregateRote<BillId>
{
    private Bill(BillId id, DinnerId dinnerId, GuestId guestIdId, HostId hostId, Price price, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        DinnerId = dinnerId;
        GuestIdId = guestIdId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public DinnerId DinnerId { get; private set; }

    public GuestId GuestIdId { get; private set; }

    public HostId HostId { get; private set; }

    public Price Price { get; private set; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Bill Create(DinnerId dinnerId, GuestId guestIdId, HostId hostId, Price price)
    {
        return new Bill(BillId.CreateUnique(), dinnerId, guestIdId, hostId, price, DateTime.UtcNow, DateTime.UtcNow);
    }
}