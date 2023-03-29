using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Common.ValueObjects;

public sealed class RatingId : ValueObject
{
    public Guid Value { get; }

    private RatingId(Guid value)
    {
        Value = value;
    }

    public static RatingId CreateUnique()
    {
        return new RatingId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}