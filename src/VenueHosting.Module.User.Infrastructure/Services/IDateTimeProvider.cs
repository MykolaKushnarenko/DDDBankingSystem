using VenueHosting.Module.User.Application.Common.Interfaces;

namespace VenueHosting.Module.User.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetUtcNow()
    {
        return DateTime.UtcNow;
    }
}