using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Application.Common.Specifications;

public sealed class FindPlaceByPlaceIdSpecification : BaseSpecification<Domain.Place.Place>
{
    public FindPlaceByPlaceIdSpecification(PlaceId id)
    {
        AddCriteria(x => x.Id == id);
    }
}