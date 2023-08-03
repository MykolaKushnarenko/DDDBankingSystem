using VenueHosting.Module.Place.Domain.Owner.ValueObjects;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Place.Domain.Owner;

public class Owner : AggregateRote<OwnerId, Guid>
{
    private readonly List<PlaceId> _placeIds = new();

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