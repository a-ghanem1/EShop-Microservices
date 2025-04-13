
namespace Catalog.API.Features.Products.GetProducts;

internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResponse>
{
    private readonly ILogger<GetProductsQueryHandler> _logger;
    private readonly IDocumentSession _session;

    public GetProductsQueryHandler(ILogger<GetProductsQueryHandler> logger, IDocumentSession session)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetProductsQuery: {@Query}", request);

        var products = await _session
            .Query<Product>()
            .ToListAsync(cancellationToken);

        return new GetProductsResponse { Products = products };
    }
}