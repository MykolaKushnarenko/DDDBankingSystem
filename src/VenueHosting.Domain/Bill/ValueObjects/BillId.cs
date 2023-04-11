using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Bill.ValueObjects;

public sealed class BillId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

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