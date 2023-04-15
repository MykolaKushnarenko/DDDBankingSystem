using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Persistence.AtomicScope;
using VenueHosting.Infrastructure.Authentication;
using VenueHosting.Infrastructure.Configuration;
using VenueHosting.Infrastructure.Persistence;
using VenueHosting.Infrastructure.Persistence.AtomicScope;
using VenueHosting.Infrastructure.Persistence.Stores;
using VenueHosting.Infrastructure.Services;

namespace VenueHosting.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {
        serviceCollection.AddAuth(builderConfiguration);

        serviceCollection.AddScoped<IUserStore, UserStore>();
        serviceCollection.AddScoped<IPlaceStore, PlaceStore>();
        serviceCollection.AddScoped<IVenueStore, VenueStore>();
        serviceCollection.AddScoped<ILesseeStore, LesseeStore>();

        serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IAtomicScope, AtomicScope>();

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<VenueHostingDbContext>(options =>
            options.UseSqlServer(
                "Data Source=(local);Initial Catalog=Local-Account-Main;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;"));

        return serviceCollection;
    }

    private static IServiceCollection AddAuth(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {
        var jwtSettings = new JwtSettings();
        builderConfiguration.Bind(JwtSettings.SectionName, jwtSettings);

        serviceCollection.AddSingleton(Options.Create(jwtSettings));

        serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        serviceCollection.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });

        return serviceCollection;
    }
}