using MediatR;
using VenueHosting.Application.Common.Interfaces;

namespace VenueHosting.Application.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegistrationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<RegistrationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // Check if user exists
        
        // Create a user
        string userId = Guid.NewGuid().ToString();
        
        // Create a token
        string token = _jwtTokenGenerator.Generate(userId, request.FirstName, request.LastName);
        
        return Task.FromResult(new RegistrationResult(Guid.NewGuid().ToString(), request.FirstName, request.LastName,
            request.Email, token));
    }
}