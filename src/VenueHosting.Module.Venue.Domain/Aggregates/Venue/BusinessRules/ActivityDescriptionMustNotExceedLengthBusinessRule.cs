using Component.Domain.BLSpecifications;
using VenueHosting.Module.Venue.Domain.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;

internal sealed class ActivityDescriptionMustNotExceedLengthBusinessRule : IBusinessRule
{
    private readonly string _description;

    public ActivityDescriptionMustNotExceedLengthBusinessRule(string description)
    {
        _description = description;
    }

    private const int MaxLengthLimit = 100;

    public void CheckIfSatisfied()
    {
        if (_description.Length > MaxLengthLimit)
        {
            throw new ActivityDescriptionMaxLengthException();
        }
    }
}