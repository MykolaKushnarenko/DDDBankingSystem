using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Place.ValueObjects;

public sealed class PlaceId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private PlaceId(){}

    private PlaceId(Guid value)
    {
        Value = value;
    }

    public static PlaceId CreateUnique()
    {
        return new PlaceId(Guid.NewGuid());
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