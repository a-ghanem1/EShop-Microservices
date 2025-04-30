using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : ICommand<CreateOrderResponse>
{
    public OrderDto Order { get; set; }
}