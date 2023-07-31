using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

public sealed class VenueReservationNotFoundException : VenueHostingCoreException
{
    private const string _message = "Venue reservation is not found.";

    public VenueReservationNotFoundException() : base(_message)
    {
    }

    public override int ErrorCode { get; } = 1000;
    public override ErrorType ErrorType { get; } = ErrorType.ResourceNotFound;
}