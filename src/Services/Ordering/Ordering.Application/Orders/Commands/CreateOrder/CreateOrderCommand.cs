namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : ICommand<CreateOrderResponse>
{
    public OrderDto Order { get; set; }
}