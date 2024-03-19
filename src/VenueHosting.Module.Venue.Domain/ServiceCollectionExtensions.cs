using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VenueHosting.Module.Venue.Domain.Services;

namespace VenueHosting.Module.Venue.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<VenueDomainService>();
        
        return serviceCollection;
    }
}