using Component.Domain.Models;

namespace VenueHosting.Module.Payment.Domain.Bill.ValueObjects;

public sealed class LesseeId : ValueObject
{
    public Guid Value { get; }

    private LesseeId(Guid value)
    {
        Value = value;
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