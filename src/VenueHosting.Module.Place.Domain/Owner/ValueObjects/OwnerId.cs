using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Place.Domain.Owner.ValueObjects;

public sealed class OwnerId : ValueObject
{
    public Guid Value { get; private set; }

    private OwnerId(){}

    private OwnerId(Guid value)
    {
        Value = value;
    }

    public static OwnerId CreateUnique()
    {
        return new OwnerId(Guid.NewGuid());
    }

    public static OwnerId Create(Guid value)
    {
        return new OwnerId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}