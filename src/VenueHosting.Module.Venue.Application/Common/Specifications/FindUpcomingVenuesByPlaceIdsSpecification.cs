using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public class FindUpcomingVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Venue.Venue>
{
    public FindUpcomingVenuesByPlaceIdsSpecification(IReadOnlyList<PlaceId> placeIds)
    {
        AddCriteria(x => x.Status == VenueStatus.Organized);
        AddCriteria(x => placeIds.Contains(x.PlaceId));
    }
}