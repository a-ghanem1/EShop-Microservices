
using Catalog.API.Common.Exceptions;

namespace Catalog.API.Features.Products.UpdateProduct;

internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResponse>
{
    private readonly IDocumentSession _session;
    public UpdateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
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