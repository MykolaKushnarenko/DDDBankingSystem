using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Owner.ValueObjects;

public sealed class OwnerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

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