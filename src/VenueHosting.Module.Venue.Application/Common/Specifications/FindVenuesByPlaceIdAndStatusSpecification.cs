using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.SharedKernel.Domain;
using VenueHosting.SharedKernel.Persistence.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindVenuesByPlaceIdAndStatusSpecification : BaseSpecification<Domain.Aggregates.Venue.Venue>
{
    public FindVenuesByPlaceIdAndStatusSpecification(Id<Place.Domain.Place.Place> placeId, VenueStatus venueStatus)
    {
        AddCriteria(x => x.VenueStatus == venueStatus);
        AddCriteria(x => x.PlaceId == placeId);
    }
}