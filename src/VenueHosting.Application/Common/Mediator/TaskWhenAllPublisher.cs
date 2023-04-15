using MediatR;

namespace VenueHosting.Application.Common.Mediator;

internal sealed class TaskWhenAllPublisher : INotificationPublisher
{
    public Task Publish(
        IEnumerable<NotificationHandlerExecutor> handlerExecutors,
        INotification notification,
        CancellationToken cancellationToken)
    {
        Task[] tasks = handlerExecutors
            .Select(handler => handler.HandlerCallback(
                notification,
                cancellationToken))
            .ToArray();

        return Task.WhenAll(tasks);
    }
}