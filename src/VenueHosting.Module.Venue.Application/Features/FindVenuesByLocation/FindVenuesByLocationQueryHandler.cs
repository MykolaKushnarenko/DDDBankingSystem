using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Application.Common.Specifications;
using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;
using VenueHosting.SharedKernel.Domain;

namespace VenueHosting.Module.Venue.Application.Features.FindVenuesByLocation;

internal sealed class FindVenuesByLocationQueryHandler :
    IRequestHandler<FindVenuesByLocationQuery, IReadOnlyList<Domain.Aggregates.Venue.Venue>>
{
    private readonly IPlaceStore _placeStore;
    private readonly IVenueStore _venueStore;

    public FindVenuesByLocationQueryHandler(IVenueStore venueStore, IPlaceStore placeStore)
    {
        _placeStore = placeStore;
        _venueStore = venueStore;
    }

    public async Task<IReadOnlyList<Domain.Aggregates.Venue.Venue>> Handle(FindVenuesByLocationQuery request,
        CancellationToken cancellationToken)
    {
        FindPlacesByLocationDetailsSpecification findPlacesByLocationDetailsSpecification =
            new(request.Country, request.City, request.Street);

        //Implement the nearest search.
        var nearbyPlaces =
            await _placeStore.FetchAllBySpecificationAsync(findPlacesByLocationDetailsSpecification, cancellationToken);

        List<Id<Domain.Replicas.Place.Place>> placeIds = nearbyPlaces.Select(x => new Id<Domain.Replicas.Place.Place>(x.Id.Value))
            .ToList();

        var findUpcomingVenuesByPlaceIdsSpec =
            new FindUpcomingVenuesByPlaceIdsSpecification(placeIds);

        var nearbyVenues =
            await _venueStore.FetchAllBySpecificationAsync(findUpcomingVenuesByPlaceIdsSpec, cancellationToken);

        return nearbyVenues;
    }
}