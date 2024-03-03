using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindPlaceByPlaceIdSpecification : BaseSpecification<Domain.Replicas.Place.Place>
{
    public FindPlaceByPlaceIdSpecification(PlaceId id)
    {
        AddCriteria(x => x.Id == id);
    }
}