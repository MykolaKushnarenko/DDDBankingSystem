using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Place;

public class Place : Entity<PlaceId>
{
    private Place(){}

    private Place(PlaceId placeId, string country, string city, string street)
    {
        Id = placeId;
        Country = country;
        City = city;
        Street = street;
    }

    public string Country { get; private set; }

    public string City { get; private set; }

    public string Street { get; private set; }

    public static Place Create(PlaceId placeId, string country, string city, string street)
    {
        return new Place(placeId, country, city, street);
    }
}