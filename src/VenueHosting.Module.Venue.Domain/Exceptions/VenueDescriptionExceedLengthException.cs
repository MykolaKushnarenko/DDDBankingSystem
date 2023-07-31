using VenueHosting.Module.Venue.Application;
using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

internal sealed class VenueDescriptionExceedLengthException : VenueHostingCoreException
{
    public VenueDescriptionExceedLengthException() : base(VenueErrors.VenueDescriptionExceedLength)
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;
}