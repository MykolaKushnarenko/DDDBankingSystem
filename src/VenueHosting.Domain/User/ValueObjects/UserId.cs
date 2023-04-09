namespace VenueHosting.Domain.User.ValueObjects;

public sealed record UserId(Guid Value)
{
    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }
}