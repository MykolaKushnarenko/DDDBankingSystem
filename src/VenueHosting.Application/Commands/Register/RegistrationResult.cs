namespace VenueHosting.Application.Commands.Register;

public record RegistrationResult(string Id,
    string FirstName, 
    string LastName, 
    string Email, 
    string Token);