using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Application.Common.Specifications;

public sealed class FindVenuesByPlaceIdAndStatusSpecification : BaseSpecification<Domain.Venue.Venue>
{
    public FindVenuesByPlaceIdAndStatusSpecification(PlaceId placeId, VenueStatus venueStatus)
    {
        AddCriteria(x => x.Status == venueStatus);
        AddCriteria(x => x.PlaceId == placeId);
    }
}