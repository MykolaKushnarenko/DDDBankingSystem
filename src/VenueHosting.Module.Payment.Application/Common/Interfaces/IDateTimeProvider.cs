namespace VenueHosting.Module.Payment.Application.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime GetUtcNow();
}