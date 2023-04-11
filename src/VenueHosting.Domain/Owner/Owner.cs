using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.User.ValueObjects;

namespace VenueHosting.Domain.Owner;

public class Owner : AggregateRote<OwnerId, Guid>
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