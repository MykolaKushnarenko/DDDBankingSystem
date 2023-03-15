namespace VenueHosting.Api.Presentation.Authentication;

public record AuthenticationResponse(
    string Id,
    string FirstName, 
    string LastName, 
    string Email, 
    string Token);