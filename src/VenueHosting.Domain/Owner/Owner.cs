using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.User.ValueObjects;
using VenueHosting.Domain.VenueDomain.Owner.ValueObjects;
using VenueHosting.Domain.VenueDomain.Place.ValueObjects;

namespace VenueHosting.Domain.Owner;

public class Owner : AggregateRote<OwnerId>
{
    private List<PlaceId> _placeIds = new();

    private Owner()
    {
    }

    private Owner(OwnerId id, UserId userId) : base(id)
    {
        UserId = userId;
    }

    public UserId UserId { get; private set; }

    public IReadOnlyList<PlaceId> PlaceIds => _placeIds.AsReadOnly();

    public static Owner Create(UserId userId)
    {
        return new Owner(OwnerId.CreateUnique(), userId);
    }
}