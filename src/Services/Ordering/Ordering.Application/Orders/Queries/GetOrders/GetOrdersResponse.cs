using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersResponse
{
    public PaginatedResult<OrderDto> Orders { get; set; }
}