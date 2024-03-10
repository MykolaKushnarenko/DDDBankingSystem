using Component.Domain.BLSpecifications;
using VenueHosting.Module.Place.Domain.Place.Exceptions;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Domain.Place.BusinessRules;

internal sealed class AddressMustBeValidBusinessRule : IBusinessRule
{
    private readonly Address _address;

    public AddressMustBeValidBusinessRule(Address address)
    {
        _address = address;
    }

    public void CheckIfSatisfied()
    {
        AddressCityEmptyException.ThrowIfNullOrEmpty(_address.City);
        AddressCountryEmptyException.ThrowIfNullOrEmpty(_address.Country);
        AddressStreetEmptyException.ThrowIfNullOrEmpty(_address.Street);
        AddressNumberInvalidEmptyException.ThrowIfLessThanZero(_address.Number);
    }
}