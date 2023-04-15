using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Application.Features.Venue.FindVenuesByLocation;

internal sealed class FindVenuesByLocationQueryHandler : IRequestHandler<FindVenuesByLocationQuery, IReadOnlyList<Domain.Venue.Venue>>
{
    private readonly IPlaceStore _placeStore;
    private readonly IVenueStore _venueStore;

    public FindVenuesByLocationQueryHandler(IPlaceStore placeStore, IVenueStore venueStore)
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

        FindVenuesByPlaceIdsSpecification findVenuesByPlaceIdsSpec =
            new FindVenuesByPlaceIdsSpecification(nearbyPlaces.Select(x => PlaceId.Create(x.Id.Value)).ToList());

        IReadOnlyList<Domain.Venue.Venue?> nearbyVenues =
            await _venueStore.FetchAllBySpecificationAsync(findVenuesByPlaceIdsSpec, cancellationToken);

        return nearbyVenues;
    }
}