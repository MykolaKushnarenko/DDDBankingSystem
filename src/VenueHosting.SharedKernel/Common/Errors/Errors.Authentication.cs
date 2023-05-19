using ErrorOr;

namespace VenueHosting.SharedKernel.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict("Auth.InvalidCredentials", "Invalid credentials.");
    }
}