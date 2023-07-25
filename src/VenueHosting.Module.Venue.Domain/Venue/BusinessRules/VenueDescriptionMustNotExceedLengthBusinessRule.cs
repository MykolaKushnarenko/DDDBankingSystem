using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Venue.BusinessRules;

internal sealed class VenueDescriptionMustNotExceedLengthBusinessRule : IBusinessRule
{
    private readonly string _description;

    private const int ExpectedLength = 100;

    public VenueDescriptionMustNotExceedLengthBusinessRule(string description)
    {
        _description = description;
    }

    public void CheckIfSatisfied()
    {
        if (_description.Length > ExpectedLength)
        {
            throw new VenueDescriptionExceedLengthException();
        }
    }
}