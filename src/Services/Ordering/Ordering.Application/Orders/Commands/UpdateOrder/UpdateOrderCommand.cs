namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : ICommand<UpdateOrderResponse>
{
    public OrderDto Order { get; set; }
}