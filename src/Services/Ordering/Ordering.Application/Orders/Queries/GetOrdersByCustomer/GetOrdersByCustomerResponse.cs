namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerResponse
{
    public IEnumerable<OrderDto> Orders { get; set; }    
}