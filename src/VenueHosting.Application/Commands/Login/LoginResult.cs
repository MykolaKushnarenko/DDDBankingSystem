using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Commands.Login;

public record LoginResult(User User, 
    string Token);