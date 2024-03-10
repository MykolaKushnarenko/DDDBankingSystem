using Component.Domain.Models;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Domain.Place.Entities;

public class Facility : Entity<Facility>
{
    private Facility(){}

    private Facility(Id<Facility> value, string name, string description, int quantity) : base(value)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
    }

    public string Description { get; private set; }

    public string Name { get; private set; }

    public int Quantity { get; private set; }

    public static Facility Create(string name, string description, int quantity)
    {
        return new Facility(Id<Facility>.CreateUnique(), name, description, quantity);
    }
}