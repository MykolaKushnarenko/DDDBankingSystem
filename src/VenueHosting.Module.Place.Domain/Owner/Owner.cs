using Component.Domain.Models;
using VenueHosting.Module.Place.Domain.Owner.ValueObjects;

namespace VenueHosting.Module.Place.Domain.Owner;

public class Owner : AggregateRote<Owner>
{
    private readonly List<Id<Place.Place>> _placeIds = new();

    private Owner()
    {
    }

    private Owner(Id<Owner> id, UserId userId) : base(id)
    {
        UserId = userId;
    }

    public UserId UserId { get; private set; }

    public IReadOnlyList<Id<Place.Place>> PlaceIds => _placeIds.AsReadOnly();

    public static Owner Create(UserId userId)
    {
        return new Owner(Id<Owner>.CreateUnique(), userId);
    }
}