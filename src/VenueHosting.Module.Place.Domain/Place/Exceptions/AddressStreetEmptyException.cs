using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Place.Domain.Place.Exceptions;

internal sealed class AddressStreetEmptyException : VenueHostingCoreException
{
    public AddressStreetEmptyException() : base("")
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;

    public static void ThrowIfNullOrEmpty(string street)
    {
        if (string.IsNullOrEmpty(street))
        {
            throw new AddressStreetEmptyException();
        }
    }
}