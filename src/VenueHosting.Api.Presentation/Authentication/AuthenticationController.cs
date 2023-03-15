using MediatR;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Application.Commands.Login;
using VenueHosting.Application.Commands.Register;

namespace VenueHosting.Api.Presentation.Authentication;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterUserCommand command = new(request.FirstName, request.LastName, request.Email, request.Password);
        RegistrationResult result = await _mediator.Send(command);

        AuthenticationResponse response = new(
            result.User.Id, 
            result.User.FirstName, 
            result.User.LastName, 
            result.User.Email, 
            result.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginCommand command = new(request.Email, request.Password);
        LoginResult result = await _mediator.Send(command);

        AuthenticationResponse response = new(
            result.User.Id, 
            result.User.FirstName, 
            result.User.LastName, 
            result.User.Email, 
            result.Token);
        return Ok(response);
    }
}