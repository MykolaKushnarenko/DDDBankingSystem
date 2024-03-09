using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.SharedKernel.Domain;
using VenueHosting.SharedKernel.Persistence.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public class FindUpcomingVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Aggregates.Venue.Venue>
{
    public FindUpcomingVenuesByPlaceIdsSpecification(IReadOnlyList<Id<Domain.Replicas.Place.Place>> placeIds)
    {
        AddCriteria(x => x.VenueStatus == VenueStatus.Organized);
    }
}