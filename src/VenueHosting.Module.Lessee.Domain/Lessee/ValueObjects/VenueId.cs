using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Lessee.Domain.Lessee.ValueObjects;

public sealed class VenueId : ValueObject
{
    public Guid Value { get; private set; }

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