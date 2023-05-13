using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Attendee.Domain.Attendee.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; private set; }

    private BillId(){}

    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public static BillId Create(Guid value)
    {
        return new BillId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}