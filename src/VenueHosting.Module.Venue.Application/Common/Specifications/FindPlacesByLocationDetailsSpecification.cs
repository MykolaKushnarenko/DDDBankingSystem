using System.Linq.Expressions;
using VenueHosting.Module.Venue.Domain.Place;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Specifications;

public sealed class FindPlacesByLocationDetailsSpecification : BaseSpecification<Domain.Place.Place>
{
    public FindPlacesByLocationDetailsSpecification(string country, string city, string street)
    {
        Expression<Func<Domain.Place.Place, bool>> criteria = x =>
            x.Country == country &&
            x.City == city &&
            x.Street == street;

        AddCriteria(criteria);
    }
}