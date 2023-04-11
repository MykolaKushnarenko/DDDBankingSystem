using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Venue.ValueObjects;

public sealed class VenueId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private VenueId()
    {
    }

    private VenueId(Guid value)
    {
        Value = value;
    }

    public static VenueId CreateUnique()
    {
        return new VenueId(Guid.NewGuid());
    }

    public static VenueId Create(Guid value)
    {
        return new VenueId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}