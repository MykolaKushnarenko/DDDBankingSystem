using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

internal sealed class ActivityNameMaxLengthException : VenueHostingCoreException
{
    public ActivityNameMaxLengthException() : base("")
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;
}