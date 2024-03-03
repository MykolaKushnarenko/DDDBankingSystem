using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindVenuesByPlaceIdAndStatusSpecification : BaseSpecification<Domain.Aggregates.Venue.Venue>
{
    public FindVenuesByPlaceIdAndStatusSpecification(PlaceId placeId, VenueStatus venueStatus)
    {
        AddCriteria(x => x.Status == venueStatus);
        AddCriteria(x => x.PlaceId == placeId);
    }
}