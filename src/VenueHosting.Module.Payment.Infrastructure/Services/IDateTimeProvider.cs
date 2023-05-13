using VenueHosting.Application.Common.Interfaces;

namespace VenueHosting.Module.Payment.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetUtcNow()
    {
        return DateTime.UtcNow;
    }
}