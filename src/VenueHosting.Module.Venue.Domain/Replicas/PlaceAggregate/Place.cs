using Component.Domain.Models;
using JetBrains.Annotations;

namespace VenueHosting.Module.Venue.Domain.Replicas.PlaceAggregate;

public class Place : AggregateRote<Place>
{
    private Place(){}

    private Place(Id<Place> placeId, string country, string city, string street) : base(placeId)
    {
        Country = country;
        City = city;
        Street = street;
    }

    public string Country { get; private set; } = null!;

    public string City { get; private set; } = null!;

    public string Street { get; private set; } = null!;

    public static Place Create(Id<Place> placeId, string country, string city, string street)
    {
        return new Place(placeId, country, city, street);
    }
}