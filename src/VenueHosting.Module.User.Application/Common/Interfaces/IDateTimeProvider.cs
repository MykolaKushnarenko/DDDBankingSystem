namespace VenueHosting.Module.User.Application.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime GetUtcNow();
}