using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Consumers.Consts;
using VenueHosting.Module.Venue.Consumers.OrganizeVenue;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Module.Venue.Consumers;

public static class DependencyInjection
{
    public static IServiceCollection AddMassTransitGlobal(this IServiceCollection serviceCollection)
    {

        return serviceCollection;
    }
}