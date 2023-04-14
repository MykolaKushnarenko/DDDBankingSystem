using System.Linq.Expressions;
using VenueHosting.Application.Common.Specifications;

namespace VenueHosting.Application.Features.Venue.FindVenuesByLocation.Specifications;

public sealed class FindPlacesByLocationDetailsSpecification : BaseSpecification<Domain.Place.Place>
{
    public FindPlacesByLocationDetailsSpecification(string country, string city, string street)
    {
        Expression<Func<Domain.Place.Place, bool>> criteria = x =>
            x.Address.Country == country &&
            x.Address.City == city &&
            x.Address.Street == street;

        AddCriteria(criteria);
    }
}