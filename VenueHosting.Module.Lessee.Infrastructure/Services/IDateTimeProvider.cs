using VenueHosting.Application.Common.Interfaces;

namespace VenueHosting.Module.Lessee.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetUtcNow()
    {
        return DateTime.UtcNow;
    }
}