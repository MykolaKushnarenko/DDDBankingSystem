using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;

internal sealed class ActivityNameMustNotExceedLengthBusinessRule : IBusinessRule
{
    private readonly string _name;

    private const int LengthLimit = 10;

    public ActivityNameMustNotExceedLengthBusinessRule(string name)
    {
        _name = name;
    }

    public void CheckIfSatisfied()
    {
        if (_name.Length > LengthLimit)
        {
            throw new AccessViolationException();
        }
    }
}