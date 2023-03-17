using ErrorOr;
using MediatR;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Common.Errors;
using VenueHosting.Domain.Entities;

namespace VenueHosting.Application.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,ErrorOr<RegistrationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserStore _userStore;

    public RegisterUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserStore userStore)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userStore = userStore;
    }

    public Task<ErrorOr<RegistrationResult>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        ErrorOr<RegistrationResult> result;
        if (_userStore.GetByEmail(request.Email) is not null)
        {
            result = Errors.User.DuplicateEmail;
            return Task.FromResult(result);
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

        result = new RegistrationResult(user, token);
        return Task.FromResult(result);
    }
}