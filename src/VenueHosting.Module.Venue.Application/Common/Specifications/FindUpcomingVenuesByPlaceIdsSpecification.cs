using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public class FindUpcomingVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Aggregates.Venue.Venue>
{
    public FindUpcomingVenuesByPlaceIdsSpecification(IReadOnlyList<PlaceId> placeIds)
    {
        AddCriteria(x => x.Status == VenueStatus.Organized);
        AddCriteria(x => placeIds.Contains(x.PlaceId));
    }
}