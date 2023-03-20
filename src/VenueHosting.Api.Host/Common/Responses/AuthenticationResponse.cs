namespace VenueHosting.Api.Host.Common.Responses;

public record AuthenticationResponse(
    string Id,
    string FirstName, 
    string LastName, 
    string Email, 
    string Token);