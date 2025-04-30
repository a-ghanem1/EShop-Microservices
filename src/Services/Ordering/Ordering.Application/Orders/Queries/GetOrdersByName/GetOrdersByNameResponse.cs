namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameResponse
{
    public IEnumerable<OrderDto> Orders { get; set; }    
}