using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Application.Common.Specifications;

public class FindVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Venue.Venue>
{
    public FindVenuesByPlaceIdsSpecification(IReadOnlyList<PlaceId> placeIds)
    {
        AddCriteria(x => placeIds.Contains(x.PlaceId));
    }
}