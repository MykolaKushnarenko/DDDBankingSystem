using VenueHosting.Module.Place.Domain.Place.ValueObjects;
using VenueHosting.SharedKernel.Persistence.Specifications;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Place.Application.Common.Specifications;

public sealed class FindPlaceByPlaceIdSpecification : BaseSpecification<Domain.Place.Place>
{
    public FindPlaceByPlaceIdSpecification(PlaceId id)
    {
        AddCriteria(x => x.Id == id);
    }
}