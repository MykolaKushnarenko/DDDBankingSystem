using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindPlaceByPlaceIdSpecification : BaseSpecification<Domain.Replicas.Place.Place>
{
    public FindPlaceByPlaceIdSpecification(Id<Domain.Replicas.Place.Place> id)
    {
        AddCriteria(x => x.Id == id);
    }
}