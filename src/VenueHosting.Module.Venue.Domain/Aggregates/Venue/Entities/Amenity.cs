using Component.Domain.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;

public class Amenity : Entity<Amenity>
{
    private Amenity()
    {
    }

    internal Amenity(string title, int quantity, bool isAvailable)
    {
        Title = title;
        Quantity = quantity;
        IsAvailable = isAvailable;
    }

    public string Title { get; set; } = null!;
    public int Quantity { get; set; }
    public bool IsAvailable { get; set; }
}