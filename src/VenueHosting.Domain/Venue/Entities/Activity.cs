using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Domain.Venue.Entities;

public class Activity : Entity<ActivityId>
{
    private Activity(){}

    private Activity(ActivityId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public static Activity Create(string name, string description)
    {
        return new Activity(ActivityId.CreateUnique(), name, description);
    }
}