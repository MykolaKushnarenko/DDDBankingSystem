using ErrorOr;
using MediatR;

namespace VenueHosting.Application.Features.Authentication.Login;

public record LoginQuery(
    string Email, 
    string Password) : IRequest<ErrorOr<LoginResult>>;