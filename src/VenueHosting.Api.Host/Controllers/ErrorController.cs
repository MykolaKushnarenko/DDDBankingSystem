using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Application.Common.Exceptions;

namespace VenueHosting.Api.Host.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception error = HttpContext.Features.GetRequiredFeature<IExceptionHandlerFeature>().Error;

        var (statusCode, message) = error switch
        {
            IServiceException serviceException => (serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
        };
        
        return Problem(statusCode: statusCode, title: message);
    }
}