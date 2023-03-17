namespace VenueHosting.Application.Common.Exceptions;

public interface IServiceException
{
    int StatusCode { get; }
    
    string ErrorMessage { get; }
}