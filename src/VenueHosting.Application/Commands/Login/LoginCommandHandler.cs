using ErrorOr;
using MediatR;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Common.Errors;
using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResult>>
{
    private readonly IUserStore _userStore;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IUserStore userStore, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userStore = userStore;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public Task<ErrorOr<LoginResult>>Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        ErrorOr<LoginResult> result;
        if (_userStore.GetByEmail(request.Email) is not User user)
        {
            result = Errors.Authentication.InvalidCredentials;
            return Task.FromResult(result);
        }

        if (user.Password != request.Password)
        {
            result = Errors.Authentication.InvalidCredentials;
            return Task.FromResult(result);
        }
        
        string token = _jwtTokenGenerator.Generate(user);

        result = new LoginResult(user, token);
        return Task.FromResult(result);
    }
}