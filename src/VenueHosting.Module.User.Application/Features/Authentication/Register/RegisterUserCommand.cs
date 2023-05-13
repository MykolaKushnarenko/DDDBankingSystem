using ErrorOr;
using MediatR;

namespace VenueHosting.Application.Features.Authentication.Register;

public record RegisterUserCommand(string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<RegistrationResult>>;