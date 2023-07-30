using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

public sealed class VenueNotFoundException : VenueHostingCoreException
{
    private const string _message = "Venue not found.";

    public VenueNotFoundException() : base(_message)
    {
    }

    public override int ErrorCode { get; } = 1000;
    public override ErrorType ErrorType { get; } = ErrorType.ResourceNotFound;
}