using Component.Domain.Models;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Repositories;
using VenueHosting.Module.Venue.Domain.Specifications.VenueAggregate;

namespace VenueHosting.Module.Venue.Application.Extensions;

internal static class VenueRepositoryExtensions
{
    public static async Task<Domain.Aggregates.VenueAggregate.Venue> FindOneOrThrowAsync(
        this IVenueRepository repository,
        Id<Domain.Aggregates.VenueAggregate.Venue> id,
        CancellationToken cancellationToken)
    {
        var venue = await repository.FindOneAsync(VenueByVenueIdSpec.Create(id), cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException(id);
        }

        return venue;
    }
}