using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Place.Domain.Place.ValueObjects;

public sealed class PlaceId : ValueObject
{
    public Guid Value { get; private set; }

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