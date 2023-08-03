using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Place.Domain.Place.Exceptions;

internal sealed class AddressCityEmptyException : VenueHostingCoreException
{
    public AddressCityEmptyException() : base("")
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;

    public static void ThrowIfNullOrEmpty(string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            throw new AddressCityEmptyException();
        }
    }
}