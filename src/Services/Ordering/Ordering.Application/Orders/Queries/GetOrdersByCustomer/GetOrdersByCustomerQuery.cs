namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerQuery : IQuery<GetOrdersByCustomerResponse>
{
    public Guid CustomerId { get; set; }
}