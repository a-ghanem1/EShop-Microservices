
namespace Catalog.API.Features.Products.GetProductsByCategory;

internal class GetProductsByCategoryHandler : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResponse>
{
    private readonly ILogger<GetProductsByCategoryHandler> _logger;
    private readonly IDocumentSession _session;

    public GetProductsByCategoryHandler(ILogger<GetProductsByCategoryHandler> logger, IDocumentSession session)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductsByCategoryResponse> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetProductsByCategoryQuery: {@Query}", request);

        var products = await _session
            .Query<Product>()
            .Where(p => p.Categories.Contains(request.Category))
            .ToListAsync(cancellationToken);

        return new GetProductsByCategoryResponse { Products = products };
    }
}