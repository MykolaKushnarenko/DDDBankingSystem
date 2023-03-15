using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string Generate(User user);
}