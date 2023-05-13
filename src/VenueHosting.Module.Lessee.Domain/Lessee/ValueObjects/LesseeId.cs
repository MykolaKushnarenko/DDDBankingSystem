using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Lessee.Domain.Lessee.ValueObjects;

public sealed class LesseeId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private LesseeId(){}

    private LesseeId(Guid value)
    {
        Value = value;
    }

    public static LesseeId CreateUnique()
    {
        return new LesseeId(Guid.NewGuid());
    }

    public static LesseeId Create(Guid value)
    {
        return new LesseeId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}