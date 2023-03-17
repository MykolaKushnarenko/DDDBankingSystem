using System.Net;
using System.Text.Json;

namespace VenueHosting.Api.Host.Middlewares;

public class GlobalErrorHandlingMiddleware
{
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
        catch (Exception e)
        {
            await HandleException(context, e);
        }
    }

    private static Task HandleException(HttpContext context, Exception error)
    {
        HttpStatusCode internalSystemError = HttpStatusCode.InternalServerError;
        string errorContentJson = JsonSerializer.Serialize(
            new { error = "An error occured while processing a request." },
            new JsonSerializerOptions(new JsonSerializerOptions(JsonSerializerDefaults.Web)));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)internalSystemError;
        return context.Response.WriteAsync(errorContentJson);
    }
}