using System.Linq.Expressions;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Application.Features.Venue.FindVenuesByLocation.Specifications;

public class FindVenuesByPlaceIdsSpecification : BaseSpecification<Domain.Venue.Venue>
{
    public FindVenuesByPlaceIdsSpecification(IReadOnlyList<PlaceId> placeIds)
    {
        Expression<Func<Domain.Venue.Venue, bool>> criteria = x => placeIds.Contains(x.PlaceId);

        AddCriteria(criteria);
    }
}