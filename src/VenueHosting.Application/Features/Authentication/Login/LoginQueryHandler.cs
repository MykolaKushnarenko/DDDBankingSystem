using ErrorOr;
using MediatR;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Common.Errors;
using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Features.Authentication.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<LoginResult>>
{
    private readonly IUserStore _userStore;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserStore userStore, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userStore = userStore;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public Task<ErrorOr<LoginResult>>Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        ErrorOr<LoginResult> result;
        if (_userStore.GetByEmail(query.Email) is not User user)
        {
            result = Errors.Authentication.InvalidCredentials;
            return Task.FromResult(result);
        }

        if (user.Password != query.Password)
        {
            result = Errors.Authentication.InvalidCredentials;
            return Task.FromResult(result);
        }
        
        string token = _jwtTokenGenerator.Generate(user);

        result = new LoginResult(user, token);
        return Task.FromResult(result);
    }
}