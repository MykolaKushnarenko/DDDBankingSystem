using Component.Domain.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;

public class Activity : Entity<Activity>
{
    private Activity(){}

    internal Activity(string name, string description, Id<Activity>? id = null)
        : base(id ?? Id<Activity>.CreateUnique())
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    internal void ChangeName(string name)
    {
        Name = name;
    }

    internal void ChangeDescription(string description)
    {
        Description = description;
    }
}