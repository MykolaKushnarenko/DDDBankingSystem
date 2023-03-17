using Microsoft.AspNetCore.Http;

namespace VenueHosting.Application.Common.Exceptions;

public class DuplicateEmailException : Exception, IServiceException
{
    public int StatusCode => StatusCodes.Status409Conflict;
    
    public string ErrorMessage => "Email already exists.";
}