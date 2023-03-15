namespace VenueHosting.Application.Commands.Login;

public record LoginResult(string Id,
    string FirstName, 
    string LastName, 
    string Email, 
    string Token);