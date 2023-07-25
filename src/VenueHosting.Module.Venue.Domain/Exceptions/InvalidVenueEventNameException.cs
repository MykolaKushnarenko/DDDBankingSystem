using VenueHosting.Module.Venue.Application;
using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

internal sealed class InvalidVenueEventNameException : VenueHostingCoreException
{
    public InvalidVenueEventNameException() : base(VenueErrors.InvalidVenueEventName)
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;
}