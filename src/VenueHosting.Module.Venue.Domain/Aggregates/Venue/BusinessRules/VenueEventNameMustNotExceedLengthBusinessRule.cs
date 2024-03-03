using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;

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