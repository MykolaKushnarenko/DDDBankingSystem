using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Infrastructure.Persistence.Stores;
using VenueHosting.Module.User.Application;
using VenueHosting.Module.User.Application.Common.Interfaces;
using VenueHosting.Module.User.Infrastructure.Authentication;
using VenueHosting.Module.User.Infrastructure.Configuration;
using VenueHosting.Module.User.Infrastructure.Persistence;
using VenueHosting.Module.User.Infrastructure.Persistence.AtomicScope;
using VenueHosting.Module.User.Infrastructure.Services;

namespace VenueHosting.Module.User.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {
        serviceCollection.AddAuth(builderConfiguration);

        serviceCollection.AddScoped<IUserStore, UserStore>();

        serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IAtomicScope, AtomicScope>();

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<UserApplicationDbContext>(options =>
            options.UseSqlServer(
                "Data Source=(local);Initial Catalog=Local-Account-Main;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;",
                builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "User")));

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