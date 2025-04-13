namespace Catalog.API.Features.Products.CreateProduct;

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
   private readonly IDocumentSession _session;
   public CreateProductCommandHandler(IDocumentSession session)
   {
      _session = session;
   }

   public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
   {
      var product = command.Adapt<Product>();

      _session.Store(product);
      await _session.SaveChangesAsync(cancellationToken);

      return product.Adapt<CreateProductResponse>();
   }
}