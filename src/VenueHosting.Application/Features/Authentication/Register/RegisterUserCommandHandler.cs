using ErrorOr;
using MediatR;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Common.Errors;
using VenueHosting.Domain.User;

namespace VenueHosting.Application.Features.Authentication.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,ErrorOr<RegistrationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserStore _userStore;

    public RegisterUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserStore userStore)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userStore = userStore;
    }

    public Task<ErrorOr<RegistrationResult>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        ErrorOr<RegistrationResult> result;
        if (_userStore.GetByEmail(command.Email) is not null)
        {
            result = Errors.User.DuplicateEmail;
            return Task.FromResult(result);
        }

        User user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );

        _userStore.Add(user);
        
        string token = _jwtTokenGenerator.Generate(user);

        result = new RegistrationResult(user, token);
        return Task.FromResult(result);
    }
}