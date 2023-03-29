using VenueHosting.Domain.User;

namespace VenueHosting.Application.Common.Persistence;

public interface IUserStore
{
    User? GetByEmail(string email);
    
    void Add(User user);
}