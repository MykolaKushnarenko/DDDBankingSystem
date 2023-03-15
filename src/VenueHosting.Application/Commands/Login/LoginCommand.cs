using MediatR;

namespace VenueHosting.Application.Commands.Login;

public record LoginCommand(
    string Email, 
    string Password) : IRequest<LoginResult>;