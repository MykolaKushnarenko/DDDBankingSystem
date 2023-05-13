using VenueHosting.Module.Place.Domain.Owner.ValueObjects;
using VenueHosting.Module.Place.Domain.Place.Entities;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

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

    public void ReservePlace()
    {
        if (Status is PlaceStatus.Reserved)
        {
            throw new AggregateException("Place already reserved.");
        }


        Status = PlaceStatus.Reserved;
    }

    public void BookPlace()
    {
        if (Status is PlaceStatus.Booked)
        {
            throw new AggregateException("Cannot book already booked place.");
        }

        Status = PlaceStatus.Booked;
    }

    public void FreePlace()
    {
        Status = PlaceStatus.Free;
    }
}