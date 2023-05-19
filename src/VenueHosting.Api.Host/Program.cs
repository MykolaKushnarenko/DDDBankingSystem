using VenueHosting.Api.Host;
using VenueHosting.Configuration.Extensions;
using VenueHosting.Module.User.Application;
using VenueHosting.Module.User.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddUserInfrastructure(builder.Configuration);

    builder.Services.AddVenueModule(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}