using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; private set; }

    private HostId()
    {
    }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(string id)
    {
        return new HostId(Guid.Parse(id));
    }

    public static HostId Create(Guid id)
    {
        return new HostId(id);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}