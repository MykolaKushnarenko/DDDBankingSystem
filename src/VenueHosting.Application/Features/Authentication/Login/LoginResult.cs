using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Features.Authentication.Login;

public record LoginResult(User User, 
    string Token);