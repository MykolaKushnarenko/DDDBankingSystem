using Component.Domain.Models;

namespace VenueHosting.Module.Place.Domain.Owner.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; private set; }

    private UserId(){}

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}