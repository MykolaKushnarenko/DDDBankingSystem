using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Application.Common.Specifications;
using VenueHosting.Module.Venue.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.FindVenuesByLocation;

internal sealed class FindVenuesByLocationQueryHandler : IRequestHandler<FindVenuesByLocationQuery, IReadOnlyList<Domain.Venue.Venue>>
{
    private readonly IPlaceStore _placeStore;
    private readonly IVenueStore _venueStore;

    public FindVenuesByLocationQueryHandler(IVenueStore venueStore, IPlaceStore placeStore)
    {
        _placeStore = placeStore;
        _venueStore = venueStore;
    }

    public async Task<IReadOnlyList<Domain.Venue.Venue>> Handle(FindVenuesByLocationQuery request,
        CancellationToken cancellationToken)
    {
         FindPlacesByLocationDetailsSpecification findPlacesByLocationDetailsSpecification =
             new(request.Country, request.City, request.Street);

         IReadOnlyList<Domain.Place.Place> nearbyPlaces =
             await _placeStore.FetchAllBySpecificationAsync(findPlacesByLocationDetailsSpecification, cancellationToken);

         FindUpcomingVenuesByPlaceIdsSpecification findUpcomingVenuesByPlaceIdsSpec =
             new FindUpcomingVenuesByPlaceIdsSpecification(nearbyPlaces.Select(x => PlaceId.Create(x.Id.Value)).ToList());

         IReadOnlyList<Domain.Venue.Venue?> nearbyVenues =
             await _venueStore.FetchAllBySpecificationAsync(findUpcomingVenuesByPlaceIdsSpec, cancellationToken);

        return nearbyVenues;
    }
}