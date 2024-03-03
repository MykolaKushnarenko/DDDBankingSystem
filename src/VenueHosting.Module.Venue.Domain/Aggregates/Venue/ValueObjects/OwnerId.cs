
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

public sealed class OwnerId : ValueObject
{
    public Guid Value { get; }

    private OwnerId(Guid value)
    {
        Value = value;
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