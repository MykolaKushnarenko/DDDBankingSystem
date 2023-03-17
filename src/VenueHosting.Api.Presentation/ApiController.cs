using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Api.Presentation.Common.Consts;

namespace VenueHosting.Api.Presentation;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(IList<Error> errors)
    {
        HttpContext.Items[HttpContextItemKeys.ErrorCodes] = errors;
        
        Error error = errors[0];

        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
        };
        
        return Problem(statusCode: statusCode, title: error.Description);
    }
}