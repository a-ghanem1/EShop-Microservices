using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public class OrderDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string OrderName { get; set; } = default!;
    public AddressDto ShippingAddress { get; set; } = default!;
    public AddressDto BillingAddress { get; set; } = default!;
    public PaymentDto Payment { get; set; } = default!;
    public OrderStatus Status { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
}
