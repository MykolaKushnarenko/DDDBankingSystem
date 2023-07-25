using System.Text.Json;
using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Api.Host.Middlewares;

public class GlobalErrorHandlingMiddleware
{
    private readonly Dictionary<ErrorType, int> _errorTypeToHttpStatusCodeMap = new()
    {
        { ErrorType.ClientError, StatusCodes.Status400BadRequest },
        { ErrorType.ServerError, StatusCodes.Status500InternalServerError },
        { ErrorType.AuthenticationRequired, StatusCodes.Status401Unauthorized },
        { ErrorType.ResourceNotFound, StatusCodes.Status404NotFound },
        { ErrorType.ResourceAlreadyExists, StatusCodes.Status409Conflict },
        { ErrorType.AccessForbidden, StatusCodes.Status403Forbidden },
        { ErrorType.FailedDependency, StatusCodes.Status424FailedDependency },
        { ErrorType.NotAllowed, StatusCodes.Status405MethodNotAllowed }
    };

    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (VenueHostingCoreException ex)
        {
            await HandleVenueHostingExceptionAsync(context, ex);
        }
        catch (Exception e)
        {
            await HandleUnexpectedExceptionAsync(context, e);
        }
    }

    private Task HandleUnexpectedExceptionAsync(HttpContext context, Exception ex)
    {
        int statusCode = _errorTypeToHttpStatusCodeMap[ErrorType.ServerError];
        var errorBody = new { Message = "An error occured while processing a request." };

        return WriteResponseAsync(context, statusCode, errorBody);
    }

    private Task HandleVenueHostingExceptionAsync(HttpContext context, VenueHostingCoreException ex)
    {
        int statusCode = _errorTypeToHttpStatusCodeMap[ex.ErrorType];

        var errorBody =
            new
            {
                ex.Message,
                Code = ex.ErrorCode
            };

        return WriteResponseAsync(context, statusCode, errorBody);
    }

    private Task WriteResponseAsync(HttpContext context, int code, object body)
    {
        string errorContentJson = JsonSerializer.Serialize(body,
            new JsonSerializerOptions(new JsonSerializerOptions(JsonSerializerDefaults.Web)));
        context.Response.StatusCode = code;

        return context.Response.WriteAsync(errorContentJson);
    }
}