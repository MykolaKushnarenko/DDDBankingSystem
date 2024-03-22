using Components.Validation.Exceptions;

namespace VenueHosting.Api.Host.ExceptionHandlers;

internal static class ErrorCodeExtensions
{
    public static int ToStatusCode(this ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.ClientError => StatusCodes.Status400BadRequest,
            ErrorType.ServerError => StatusCodes.Status500InternalServerError,
            ErrorType.AuthenticationRequired => StatusCodes.Status401Unauthorized,
            ErrorType.ResourceNotFound => StatusCodes.Status404NotFound,
            ErrorType.ResourceAlreadyExists => StatusCodes.Status409Conflict,
            ErrorType.AccessForbidden => StatusCodes.Status403Forbidden,
            ErrorType.FailedDependency => StatusCodes.Status424FailedDependency,
            ErrorType.NotAllowed => StatusCodes.Status405MethodNotAllowed,
            _ => throw new ArgumentOutOfRangeException(nameof(errorType), errorType,
                $"There is no match for {errorType}")
        };
    }
}