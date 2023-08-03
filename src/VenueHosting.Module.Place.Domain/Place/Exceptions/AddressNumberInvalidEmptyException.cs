using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Place.Domain.Place.Exceptions;

internal sealed class AddressNumberInvalidEmptyException : VenueHostingCoreException
{
    public AddressNumberInvalidEmptyException() : base("")
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;

    public static void ThrowIfLessThanZero(int number)
    {
        if (number <= 0)
        {
            throw new AddressNumberInvalidEmptyException();
        }
    }
}