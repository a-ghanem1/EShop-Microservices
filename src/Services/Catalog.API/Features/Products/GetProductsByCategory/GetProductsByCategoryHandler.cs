
namespace Catalog.API.Features.Products.GetProductsByCategory;

internal class GetProductsByCategoryHandler : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResponse>
{
    private readonly IDocumentSession _session;

    public GetProductsByCategoryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<GetProductsByCategoryResponse> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _session
            .Query<Product>()
            .Where(p => p.Categories.Contains(request.Category))
            .ToListAsync(cancellationToken);

        return new GetProductsByCategoryResponse { Products = products };
    }
}