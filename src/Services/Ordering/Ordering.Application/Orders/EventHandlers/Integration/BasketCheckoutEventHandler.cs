using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler : IConsumer<BasketCheckoutEvent>
{
    private readonly ISender _sender;
    private readonly ILogger<BasketCheckoutEventHandler> _logger;

    public BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        _logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await _sender.Send(command);
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto
        {
            FirstName = message.FirstName,
            LastName = message.LastName,
            EmailAddress = message.EmailAddress,
            AddressLine = message.AddressLine,
            Country = message.Country,
            State = message.State,
            ZipCode = message.ZipCode
        };

        var paymentDto = new PaymentDto
        {
            CardName = message.CardName,
            CardNumber = message.CardNumber,
            Expiration = message.Expiration,
            Cvv = message.CVV,
            PaymentMethod = message.PaymentMethod
        };

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto
        {
            Id = orderId,
            CustomerId = message.CustomerId,
            OrderName = message.UserName,
            ShippingAddress = addressDto,
            BillingAddress = addressDto,
            Payment = paymentDto,
            Status = Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems = new List<OrderItemDto>
        {
            new OrderItemDto
            {
                OrderId = orderId,
                ProductId = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                Quantity = 2,
                Price = 500
            },
            new OrderItemDto
            {
                OrderId = orderId,
                ProductId = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                Quantity = 1,
                Price = 400
            }
        }
        };

        return new CreateOrderCommand
        {
            Order = orderDto
        };
    }
}