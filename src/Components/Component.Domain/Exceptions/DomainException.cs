using Components.Validation.Exceptions;

namespace Component.Domain.Exceptions;

public class DomainException : VenueHostingCoreException
{
    public DomainException(string message) : base(message)
    {
    }

    public override int ErrorCode => 0;
    public override ErrorType ErrorType => ErrorType.ClientError;
}