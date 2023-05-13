using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindVenuesByPlaceIdAndStatusSpecification : BaseSpecification<Domain.Venue.Venue>
{
    public FindVenuesByPlaceIdAndStatusSpecification(PlaceId placeId, VenueStatus venueStatus)
    {
        AddCriteria(x => x.Status == venueStatus);
        AddCriteria(x => x.PlaceId == placeId);
    }
}