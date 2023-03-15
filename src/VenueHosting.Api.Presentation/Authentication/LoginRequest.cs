namespace VenueHosting.Api.Presentation.Authentication;

public record LoginRequest(
    string Email, 
    string Password);