using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Place.Domain.Place.Exceptions;

internal sealed class AddressCountryEmptyException : VenueHostingCoreException
{
    public AddressCountryEmptyException() : base("")
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;

    public static void ThrowIfNullOrEmpty(string country)
    {
        if (string.IsNullOrEmpty(country))
        {
            throw new AddressCountryEmptyException();
        }
    }
}