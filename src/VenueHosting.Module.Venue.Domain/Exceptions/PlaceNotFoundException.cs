using VenueHosting.Module.Venue.Application;
using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

public sealed class PlaceNotFoundException : VenueHostingCoreException
{
    public override int ErrorCode { get; } = 10000; //provide error codes.

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;

    public PlaceNotFoundException() : base(VenueErrors.PlaceNotFound)
    {
    }
}