namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Outbox;

public class OutboxIntegrationEvent
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Data { get; set; } = null!;

    public DateTime OccuredAt { get; set; }
}