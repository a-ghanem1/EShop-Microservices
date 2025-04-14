
using Catalog.API.Common.Exceptions;

namespace Catalog.API.Features.Products.GetProductById;

internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly IDocumentSession _session;

    public GetProductByIdQueryHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _session
            .Query<Product>()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        return new GetProductByIdResponse { Product = product };
    }
}