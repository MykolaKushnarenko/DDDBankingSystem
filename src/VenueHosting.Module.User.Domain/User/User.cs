using Component.Domain.Models;

namespace VenueHosting.Module.User.Domain.User;

public sealed class User : AggregateRote<User>
{
    private User(){}

    private User(Id<User> id, string firstName, string lastName, string email, string password, DateTime createdDateTime,
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
        return new User(Id<User>.CreateUnique(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
    }
}