using MediatR;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IUserStore _userStore;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IUserStore userStore, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userStore = userStore;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (_userStore.GetByEmail(request.Email) is not User user)
        {
            throw new Exception("User doesn't exist.");
        }

        if (user.Password != request.Password)
        {
            throw new Exception("Invalid password");
        }
        
        string token = _jwtTokenGenerator.Generate(user);

        return Task.FromResult(new LoginResult(user, token));
    }
}