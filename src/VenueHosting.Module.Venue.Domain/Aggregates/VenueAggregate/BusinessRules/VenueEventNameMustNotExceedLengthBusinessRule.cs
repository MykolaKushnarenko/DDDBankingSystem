using Component.Domain.BLSpecifications;
using VenueHosting.Module.Venue.Domain.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.BusinessRules;

internal sealed class VenueEventNameMustNotExceedLengthBusinessRule : IBusinessRule
{
    private readonly string _eventName;

    public VenueEventNameMustNotExceedLengthBusinessRule(string eventName)
    {
        _eventName = eventName;
    }

    public void CheckIfSatisfied()
    {
        if (string.IsNullOrEmpty(_eventName))
        {
            throw new InvalidVenueEventNameException();
        }
    }
}