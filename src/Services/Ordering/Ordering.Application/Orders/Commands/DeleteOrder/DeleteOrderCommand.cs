namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand : ICommand<DeleteOrderResponse>
{
    public Guid OrderId { get; set; }
}