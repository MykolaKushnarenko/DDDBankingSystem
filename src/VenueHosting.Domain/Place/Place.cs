using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.Entities;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Domain.Place;

public class Place : AggregateRote<PlaceId, Guid>
{
    private readonly List<Facility> _facilities = new();

    private Place(){}

    private Place(PlaceId value, OwnerId ownerId, Address address) : base(value)
    {
        OwnerId = ownerId;
        Address = address;
    }

    public Address Address { get; private set; }

    public OwnerId OwnerId { get; private set; }

    public IReadOnlyList<Facility> Facilities => _facilities.ToList().AsReadOnly();

    public PlaceStatus Status { get; private set; }

    public static Place Create(OwnerId ownerId, Address address)
    {
        return new Place(PlaceId.CreateUnique(), ownerId, address);
    }

    public void AddExistingFacilities(IEnumerable<Facility> facility)
    {
        //TODO: validation
        _facilities.AddRange(facility);
    }

    public void ProvideAddressInformation(Address address)
    {
        ArgumentException.ThrowIfNullOrEmpty(address.City);
        ArgumentException.ThrowIfNullOrEmpty(address.Country);
        ArgumentException.ThrowIfNullOrEmpty(address.Street);
        if (Address.Number <= 0)
            throw new ArgumentException(nameof(Address.Number));

        Address = address;
    }

    public void SetStatusToPending()
    {
        Status = PlaceStatus.Pending;
    }

    public void SetStatusToBooked()
    {
        Status = PlaceStatus.Booked;
    }
}