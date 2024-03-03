using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;

public sealed class PlaceId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private PlaceId()
    {
    }

    private PlaceId(Guid value)
    {
        Value = value;
    }

    public static PlaceId Create(Guid value)
    {
        return new PlaceId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}