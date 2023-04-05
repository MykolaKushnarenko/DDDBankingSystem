namespace VenueHosting.Domain.User.ValueObjects;

public sealed record UserId(Guid Value)
{
    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }
}