using Components.Validation.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace VenueHosting.Api.Host.ExceptionHandlers;

internal sealed class ExceptionHandlerToProblemDetailsHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public ExceptionHandlerToProblemDetailsHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (!CanHandleException(exception))
        {
            return false;
        }

        var applicationException = exception as VenueHostingCoreException;

        httpContext.Response.StatusCode = applicationException!.ErrorType.ToStatusCode();

        var problemContext = CreateAndPopulateProblemContext(httpContext, applicationException);

        return await _problemDetailsService.TryWriteAsync(problemContext);
    }

    private ProblemDetailsContext CreateAndPopulateProblemContext(HttpContext context,
        VenueHostingCoreException exception)
    {
        return new ProblemDetailsContext
        {
            HttpContext = context,
            ProblemDetails = new ProblemDetails
            {
                Title = "An error has occured",
                Status = exception.ErrorType.ToStatusCode(),
                Detail = exception.Message,
                Instance = context.Request.Path
            },
            Exception = exception
        };
    }

    private static bool CanHandleException(Exception exception) => exception is VenueHostingCoreException;
}