using VenueHosting.Api.Host.Middlewares;
using VenueHosting.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddVenueModule(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseGlobalExceptionHandling();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHttpsRedirection();

    app.UseRouting();
    app.MapControllers();

    app.Run();
}