using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Common.Persistence;

public interface IUserStore
{
    User? GetByEmail(string email);
    
    void Add(User user);
}