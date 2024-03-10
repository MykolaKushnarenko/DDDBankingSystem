using Component.Domain.Models;

namespace VenueHosting.Module.Venue.Domain.Replicas.Place;

public class Place : AggregateRote<Place>
{
    private Place(){}

    private Place(Id<Place> placeId, string country, string city, string street) : base(placeId)
    {
        Country = country;
        City = city;
        Street = street;
    }

    public string Country { get; private set; }

    public string City { get; private set; }

    public string Street { get; private set; }

    public static Place Create(Id<Place> placeId, string country, string city, string street)
    {
        return new Place(placeId, country, city, street);
    }
}