namespace Catalog.API.Features.Products.DeleteProduct;

public class DeleteProductCommand : ICommand<DeleteProductResponse>
{
    public Guid Id { get; set; }
}