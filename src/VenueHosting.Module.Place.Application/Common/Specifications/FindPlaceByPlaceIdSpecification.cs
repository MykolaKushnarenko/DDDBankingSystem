using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;

namespace VenueHosting.Module.Place.Application.Common.Specifications;

public sealed class FindPlaceByPlaceIdSpecification : BaseSpecification<Domain.Place.Place>
{
    public FindPlaceByPlaceIdSpecification(Id<Domain.Place.Place> id)
    {
        AddCriteria(x => x.Id == id);
    }
}