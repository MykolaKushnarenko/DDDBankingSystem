using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public class FindUpcomingVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Aggregates.VenueAggregate.Venue>
{
    public FindUpcomingVenuesByPlaceIdsSpecification(IReadOnlyList<Id<Domain.Replicas.PlaceAggregate.Place>> placeIds)
    {
        AddCriteria(x => x.VenueStatus == VenueStatus.Organized);
    }
}