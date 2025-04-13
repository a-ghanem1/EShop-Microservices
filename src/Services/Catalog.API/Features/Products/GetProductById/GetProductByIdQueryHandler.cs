
using Catalog.API.Common.Exceptions;

namespace Catalog.API.Features.Products.GetProductById;

internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly ILogger<GetProductByIdQueryHandler> _logger;
    private readonly IDocumentSession _session;

    public GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IDocumentSession session)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetProductByIdQuery: {@Query}", request);

        var product = await _session
            .Query<Product>()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (product is null)
        {
            _logger.LogWarning("Product with ID {Id} not found", request.Id);
            throw new ProductNotFoundException(request.Id);
        }

        return new GetProductByIdResponse { Product = product };
    }
}