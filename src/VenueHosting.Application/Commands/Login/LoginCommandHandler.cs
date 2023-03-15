using MediatR;

namespace VenueHosting.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    public Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new LoginResult(Guid.NewGuid().ToString(), "FirstName", "LastName", request.Email,
            "Token"));
    }
}