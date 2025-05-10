using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameQueryHandler : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResponse>
{
    private readonly IApplicationDbContext _dbContext;

    public GetOrdersByNameQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetOrdersByNameResponse> Handle(GetOrdersByNameQuery request, CancellationToken cancellationToken)
    {
        var orders = await _dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.Contains(request.Name))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);

        return new GetOrdersByNameResponse
        {
            Orders = orders.ToOrderDtoList()
        }; 
    }
}