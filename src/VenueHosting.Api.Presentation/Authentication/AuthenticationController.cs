using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Application.Features.Authentication.Login;
using VenueHosting.Application.Features.Authentication.Register;

namespace VenueHosting.Api.Presentation.Authentication;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterUserCommand command = new(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<RegistrationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(result => Ok(ToResponse(registerResult.Value)),
            Problem);
    }

    private static AuthenticationResponse ToResponse(RegistrationResult registrationResult)
    {
        return new(
            registrationResult.User.Id, 
            registrationResult.User.FirstName, 
            registrationResult.User.LastName, 
            registrationResult.User.Email, 
            registrationResult.Token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginQuery query = new(request.Email, request.Password);
        ErrorOr<LoginResult> loginResult = await _mediator.Send(query);

        return loginResult.Match(result => Ok(ToLoginResponse(loginResult.Value)),
            Problem);
    }

    private static AuthenticationResponse ToLoginResponse(LoginResult result)
    {
        return new(
            result.User.Id, 
            result.User.FirstName, 
            result.User.LastName, 
            result.User.Email, 
            result.Token);
    }
}