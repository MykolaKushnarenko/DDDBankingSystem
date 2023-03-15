namespace VenueHosting.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string Generate(string userId, string firstName, string lastName);
}