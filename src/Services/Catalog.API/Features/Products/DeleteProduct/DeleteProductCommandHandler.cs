
using Catalog.API.Common.Exceptions;

namespace Catalog.API.Features.Products.DeleteProduct;

internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<DeleteProductCommandHandler> _logger;
    public DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger, IDocumentSession session)
    {
        _logger = logger;
        _session = session;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling DeleteProductCommand: {@Request}", request);

        _session.Delete<Product>(request.Id);
        await _session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResponse
        {
            IsSuccess = true
        };
    }
}