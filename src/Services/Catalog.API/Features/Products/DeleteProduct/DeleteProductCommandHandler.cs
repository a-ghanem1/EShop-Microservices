
namespace Catalog.API.Features.Products.DeleteProduct;

internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IDocumentSession _session;
    public DeleteProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        _session.Delete<Product>(request.Id);
        await _session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResponse
        {
            IsSuccess = true
        };
    }
}