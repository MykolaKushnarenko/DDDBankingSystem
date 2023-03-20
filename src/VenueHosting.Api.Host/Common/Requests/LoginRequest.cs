namespace VenueHosting.Api.Host.Common.Requests;

public record LoginRequest(
    string Email, 
    string Password);