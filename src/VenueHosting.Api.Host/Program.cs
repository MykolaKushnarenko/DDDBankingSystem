using VenueHosting.Api.Presentation.Authentication;
using VenueHosting.Application;
using VenueHosting.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var assembly = typeof(AuthenticationController).Assembly;
    builder.Services.AddControllers().AddApplicationPart(assembly);

    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.Map("/error", (HttpContext context) => Results.Problem());
    
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}