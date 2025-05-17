using MassTransit;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<OrderCreatedEventHandler> _logger;

        public OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, ILogger<OrderCreatedEventHandler> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();

            await _publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        }
    }
}