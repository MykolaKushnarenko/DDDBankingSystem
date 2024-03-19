using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindPlaceByPlaceIdSpecification : BaseSpecification<Domain.Replicas.PlaceAggregate.Place>
{
    public FindPlaceByPlaceIdSpecification(Id<Domain.Replicas.PlaceAggregate.Place> id)
    {
        AddCriteria(x => x.Id == id);
    }
}