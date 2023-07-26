namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Outbox;

public class OutboxIntegrationEvent
{
    public int Id { get; set; }

    public string Type { get; set; }

    public string Data { get; set; }
}