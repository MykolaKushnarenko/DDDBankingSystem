using Component.Domain.Models;

namespace VenueHosting.Module.Payment.Domain.Bill.ValueObjects;

public sealed class PlaceId : ValueObject
{
    public Guid Value { get; }

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