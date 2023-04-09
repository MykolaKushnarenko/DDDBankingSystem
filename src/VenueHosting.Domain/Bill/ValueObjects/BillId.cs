namespace VenueHosting.Domain.Bill.ValueObjects;

public sealed record BillId (Guid Value)
{
    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public static BillId Create(Guid value)
    {
        return new BillId(value);
    }
}