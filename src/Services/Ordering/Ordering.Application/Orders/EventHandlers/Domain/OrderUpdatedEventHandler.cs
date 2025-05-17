namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderUpdatedEventHandler : INotificationHandler<OrderUpdatedEvent>
{
    private readonly ILogger<OrderUpdatedEventHandler> _logger;

    public OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}