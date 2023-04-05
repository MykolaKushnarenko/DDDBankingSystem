using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Place.Entities;
using VenueHosting.Domain.VenueDomain.Owner.ValueObjects;
using VenueHosting.Domain.VenueDomain.Place.ValueObjects;

namespace VenueHosting.Domain.Place;

public class Place : AggregateRote<PlaceId>
{
    private List<Facility> _facilities = new();

    private Place(){}

    private Place(PlaceId value, OwnerId ownerId) : base(value)
    {
        OwnerId = ownerId;
    }


    public OwnerId OwnerId { get; private set; }

    public IReadOnlyList<Facility> Facilities => _facilities.ToList().AsReadOnly();
}