using VenueHosting.Domain.User;

namespace VenueHosting.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string Generate(User user);
}