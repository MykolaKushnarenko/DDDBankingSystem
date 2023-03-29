using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Dinner.ValueObjects;

public sealed class Location : ValueObject
{
    private Location(string name, string address, float latitude, float longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; }
    
    public string Address { get; }
    
    public float Latitude{ get; }
    
    public float Longitude{ get; }


    public static Location Create(string name, string address, float latitude, float longitude)
    {
        return new Location(name, address, latitude, longitude);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}