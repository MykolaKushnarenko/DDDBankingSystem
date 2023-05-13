namespace VenueHosting.Module.Attendee.Application.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime GetUtcNow();
}