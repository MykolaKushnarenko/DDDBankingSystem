using MediatR;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegistrationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserStore _userStore;

    public RegisterUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserStore userStore)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userStore = userStore;
    }

    public Task<RegistrationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (_userStore.GetByEmail(request.Email) is not null)
        {
            throw new Exception("User already exists.");
        }

        User user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        _userStore.Add(user);
        
        string token = _jwtTokenGenerator.Generate(user);
        
        return Task.FromResult(new RegistrationResult(user, token));
    }
}