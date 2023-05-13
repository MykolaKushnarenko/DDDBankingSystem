using VenueHosting.Module.Place.Domain.Place.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Place.Domain.Place.Entities;

public class Facility : Entity<FacilityId>
{
    private Facility(){}

    private Facility(FacilityId value, string name, string description, int quantity) : base(value)
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
        return new Facility(FacilityId.CreateUnique(), name, description, quantity);
    }
}