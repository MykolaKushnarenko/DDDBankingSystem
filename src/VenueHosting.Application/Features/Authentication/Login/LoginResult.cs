using VenueHosting.Domain.User;

namespace VenueHosting.Application.Features.Authentication.Login;

public record LoginResult(User User, 
    string Token);