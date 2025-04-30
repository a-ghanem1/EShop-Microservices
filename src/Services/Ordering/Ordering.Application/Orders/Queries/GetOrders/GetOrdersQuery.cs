using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersQuery : IQuery<GetOrdersResponse>
{
    public PaginationRequest PaginationRequest { get; set; }
}