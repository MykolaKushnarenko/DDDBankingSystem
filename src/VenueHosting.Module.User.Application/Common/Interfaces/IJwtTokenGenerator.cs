using VenueHosting.Module.User.Domain.User;

namespace VenueHosting.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string Generate(User user);
}