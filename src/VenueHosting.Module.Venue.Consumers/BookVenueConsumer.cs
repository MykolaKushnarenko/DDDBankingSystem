using MassTransit;
using Microsoft.Extensions.Logging;
using VenueHosting.Module.Venue.Consumers.OrganizeVenue;

namespace VenueHosting.Module.Venue.Consumers;

public class BookVenueConsumer : IConsumer<BookVenueCommand>
{
    private readonly ILogger<BookVenueConsumer> _logger;

    public BookVenueConsumer(ILogger<BookVenueConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<BookVenueCommand> context)
    {
        var c = 12;
        _logger.LogWarning("Here we go!");
        return Task.CompletedTask;
    }
}