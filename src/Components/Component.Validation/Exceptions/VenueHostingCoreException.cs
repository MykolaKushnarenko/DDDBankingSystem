namespace Components.Validation.Exceptions;

public abstract class VenueHostingCoreException : Exception
{
    public abstract int ErrorCode { get; }

    public abstract ErrorType ErrorType { get; }
    
    protected VenueHostingCoreException(string message)
        : base(message)
    {
    }
}

public enum ErrorType
{
    ClientError,
    ServerError,
    AuthenticationRequired,
    ResourceNotFound,
    ResourceAlreadyExists,
    AccessForbidden,
    FailedDependency,
    NotAllowed
}