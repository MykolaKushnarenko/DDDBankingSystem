using System.Reflection;
using System.Text.Json;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VenueHosting.Contracts.Events;
using VenueHosting.Module.Venue.Infrastructure.Persistence.Outbox;
using VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace VenueHosting.Module.Venue.Infrastructure.Jobs;

internal sealed class OutboxMessageBackgroundJob : BackgroundService
{
    private readonly IBus _bus;
    private readonly IOutboxMessageStore _outboxMessageStore;
    private const int DelayInSeconds = 5;

    public OutboxMessageBackgroundJob(IBus bus,
        IServiceScopeFactory serviceScopeFactory)
    {
        _bus = bus;
        _outboxMessageStore =
            serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IOutboxMessageStore>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            IReadOnlyList<OutboxIntegrationEvent> batch = await _outboxMessageStore.FetchBatchAsync();
            foreach (OutboxIntegrationEvent outboxIntegrationEvent in batch)
            {
                Type type = Assembly.GetAssembly(typeof(VenueCreatedIntegrationEvent))!
                    .GetType(outboxIntegrationEvent.Type)!;

                object @event = JsonSerializer.Deserialize(outboxIntegrationEvent.Data, type,
                    new JsonSerializerOptions(new JsonSerializerOptions()))!;

                 await _bus.Publish(@event, stoppingToken);
            }

            await Task.Delay(TimeSpan.FromSeconds(DelayInSeconds), stoppingToken);
        }
    }
}