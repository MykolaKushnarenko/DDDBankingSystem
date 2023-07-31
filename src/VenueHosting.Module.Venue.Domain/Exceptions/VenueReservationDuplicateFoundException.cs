using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

internal sealed class VenueReservationDuplicateFoundException : VenueHostingCoreException
{
    public VenueReservationDuplicateFoundException() : base("Reservation has been already made.")
    {
    }

    public override int ErrorCode { get; } = 1000;
    public override ErrorType ErrorType { get; } = ErrorType.ResourceAlreadyExists;
}