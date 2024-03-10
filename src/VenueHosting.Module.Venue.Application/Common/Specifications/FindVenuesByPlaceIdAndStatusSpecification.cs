using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindVenuesByPlaceIdAndStatusSpecification : BaseSpecification<Domain.Aggregates.Venue.Venue>
{
    public FindVenuesByPlaceIdAndStatusSpecification(Id<Place.Domain.Place.Place> placeId, VenueStatus venueStatus)
    {
        AddCriteria(x => x.VenueStatus == venueStatus);
        AddCriteria(x => x.PlaceId == placeId);
    }
}