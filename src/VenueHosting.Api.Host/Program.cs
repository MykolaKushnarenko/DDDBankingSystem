using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VenueHosting.Api.Presentation.Authentication;
using VenueHosting.Api.Presentation.Common.Error;
using VenueHosting.Application;
using VenueHosting.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var assembly = typeof(AuthenticationController).Assembly;
    builder.Services.AddControllers().AddApplicationPart(assembly);

    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}