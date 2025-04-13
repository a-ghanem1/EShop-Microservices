
using Catalog.API.Common.Exceptions;

namespace Catalog.API.Features.Products.UpdateProduct;

internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResponse>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<UpdateProductCommandHandler> _logger;
    public UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IDocumentSession session)
    {
        _logger = logger;
        _session = session;
    }

    public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling UpdateProductCommand: {@Request}", request);

        var product = await _session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Categories = request.Categories;
        product.ImageFile = request.ImageFile;
        product.Price = request.Price;

        _session.Update(product);
        await _session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResponse
        {
            IsSuccess = true
        };
    }
}