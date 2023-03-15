using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Commands.Register;

public record RegistrationResult(User User, 
    string Token);