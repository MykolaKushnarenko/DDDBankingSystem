using VenueHosting.Module.Place.Domain.Owner.ValueObjects;
using VenueHosting.Module.Place.Domain.Place.BusinessRules;
using VenueHosting.Module.Place.Domain.Place.Entities;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Place.Domain.Place;

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

    public void AddFacilities(IList<Facility> facilities)
    {
        CheckRule(new FacilityMustNotExistBusinessRule(_facilities, facilities));

        _facilities.AddRange(facilities);
    }

    public void ProvideAddressInformation(string country, string city, string street, int number)
    {
        Address address = new(country, city, street, number);

        CheckRule(new AddressMustBeValidBusinessRule(address));

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