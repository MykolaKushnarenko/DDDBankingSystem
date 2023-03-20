using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Features.Authentication.Register;

public record RegistrationResult(User User, 
    string Token);