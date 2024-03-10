using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public class FindUpcomingVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Aggregates.Venue.Venue>
{
    public FindUpcomingVenuesByPlaceIdsSpecification(IReadOnlyList<Id<Domain.Replicas.Place.Place>> placeIds)
    {
        AddCriteria(x => x.VenueStatus == VenueStatus.Organized);
    }
}