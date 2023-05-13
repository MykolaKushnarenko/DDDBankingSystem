using VenueHosting.Module.User.Domain.User;

namespace VenueHosting.Application.Features.Authentication.Register;

public record RegistrationResult(User User, 
    string Token);