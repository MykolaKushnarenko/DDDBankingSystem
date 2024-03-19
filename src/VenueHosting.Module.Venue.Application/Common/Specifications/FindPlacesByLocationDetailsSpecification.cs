using System.Linq.Expressions;
using Component.Persistence.SqlServer.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindPlacesByLocationDetailsSpecification : BaseSpecification<Domain.Replicas.PlaceAggregate.Place>
{
    public FindPlacesByLocationDetailsSpecification(string country, string city, string street)
    {
        Expression<Func<Domain.Replicas.PlaceAggregate.Place, bool>> criteria = x =>
            x.Country == country &&
            x.City == city &&
            x.Street == street;

        AddCriteria(criteria);
    }
}