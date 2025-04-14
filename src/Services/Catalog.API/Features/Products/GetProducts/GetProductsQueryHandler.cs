
using Marten.Pagination;

namespace Catalog.API.Features.Products.GetProducts;

internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResponse>
{
    private readonly IDocumentSession _session;

    public GetProductsQueryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _session
            .Query<Product>()
            .ToPagedListAsync(
                request.PageNumber ?? 1, 
                request.PageSize ?? 10, 
                cancellationToken
            );

        return new GetProductsResponse { Products = products };
    }
}