using Microsoft.AspNetCore.Mvc.Infrastructure;
using VenueHosting.Api.Host.Common.Error;
using VenueHosting.Api.Host.Common.Mapping;

namespace VenueHosting.Api.Host;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        serviceCollection.AddMapping();
        
        return serviceCollection;
    }
}