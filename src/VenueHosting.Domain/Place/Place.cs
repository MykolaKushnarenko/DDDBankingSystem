using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.Entities;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Domain.Place;

public class Place : AggregateRote<PlaceId, Guid>
{
    private List<Facility> _facilities = new();

    private Place(){}

    private Place(PlaceId value, OwnerId ownerId, Address address) : base(value)
    {
        OwnerId = ownerId;
        Address = address;
    }

    public Address Address { get; private set; }

    public OwnerId OwnerId { get; private set; }

    public IReadOnlyList<Facility> Facilities => _facilities.ToList().AsReadOnly();

    public Place Create(OwnerId ownerId, Address address)
    {
        return new Place(PlaceId.CreateUnique(), ownerId, address);
    }
}