using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.User.ValueObjects;

namespace VenueHosting.Domain.User;

public sealed class User : AggregateRote<UserId, Guid>
{
    private User(){}

    private User(UserId id, string firstName, string lastName, string email, string password, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    //TODO: Hash this
    public string Password { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
    }
}