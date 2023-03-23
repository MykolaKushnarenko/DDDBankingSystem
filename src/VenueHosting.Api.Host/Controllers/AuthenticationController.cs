using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Api.Host.Common.Requests;
using VenueHosting.Api.Host.Common.Responses;
using VenueHosting.Application.Features.Authentication.Login;
using VenueHosting.Application.Features.Authentication.Register;

namespace VenueHosting.Api.Host.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterUserCommand command = _mapper.Map<RegisterUserCommand>(request);
        ErrorOr<RegistrationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginQuery query = _mapper.Map<LoginQuery>(request);
        ErrorOr<LoginResult> loginResult = await _mediator.Send(query);

        return loginResult.Match(result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            Problem);
    }
}