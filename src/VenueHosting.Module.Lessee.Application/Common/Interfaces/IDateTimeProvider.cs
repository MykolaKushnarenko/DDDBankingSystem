namespace VenueHosting.Application.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime GetUtcNow();
}