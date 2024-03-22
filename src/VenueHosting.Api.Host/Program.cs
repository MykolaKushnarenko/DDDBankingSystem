using VenueHosting.Api.Host.ExceptionHandlers;
using VenueHosting.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddProblemDetails();
    builder.Services.AddExceptionHandler<ExceptionHandlerToProblemDetailsHandler>();
    builder.Services.AddVenueModule(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseExceptionHandler();
    
    app.UseHttpsRedirection();

    app.UseRouting();
    app.MapControllers();

    app.Run();
}