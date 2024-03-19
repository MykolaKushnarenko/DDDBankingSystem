using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.PlaceAggregate;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindVenuesByPlaceIdAndStatusSpecification : BaseSpecification<Domain.Aggregates.VenueAggregate.Venue>
{
    public FindVenuesByPlaceIdAndStatusSpecification(Id<Place> placeId, VenueStatus venueStatus)
    {
        AddCriteria(x => x.VenueStatus == venueStatus);
        AddCriteria(x => x.PlaceId == placeId);
    }
}