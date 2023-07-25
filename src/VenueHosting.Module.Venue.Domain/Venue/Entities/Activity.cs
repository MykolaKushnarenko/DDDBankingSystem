using VenueHosting.Module.Venue.Domain.Venue.BusinessRules;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Venue.Entities;

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
        Activity activity = new(ActivityId.CreateUnique(), name, description);

        activity.CheckRule(new ActivityNameMustNotExceedLengthBusinessRule(activity.Name));
        activity.CheckRule(new ActivityDescriptionMustNotExceedLengthBusinessRule(activity.Description));

        return activity;
    }
}