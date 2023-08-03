using VenueHosting.SharedKernel.Exceptions;

namespace VenueHosting.Module.Place.Domain.Place.Exceptions;

internal sealed class FacilityDuplicateFoundException : VenueHostingCoreException
{
    public FacilityDuplicateFoundException() : base("")
    {
    }

    public override int ErrorCode { get; } = 1000;

    public override ErrorType ErrorType { get; } = ErrorType.ClientError;
}