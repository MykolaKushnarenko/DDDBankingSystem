using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Application.Common.Specifications;

public class FindUpcomingVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Venue.Venue>
{
    public FindUpcomingVenuesByPlaceIdsSpecification(IReadOnlyList<PlaceId> placeIds)
    {
        AddCriteria(x => x.Status == VenueStatus.Organized);
        AddCriteria(x => placeIds.Contains(x.PlaceId));
    }
}