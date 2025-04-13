namespace Catalog.API.Features.Products.CreateProduct;

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
   private readonly IDocumentSession _session;
   private readonly ILogger<CreateProductCommandHandler> _logger;

   public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IDocumentSession session)
   {
      _logger = logger;
      _session = session;
   }

   public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
   {
      _logger.LogInformation("Handling CreateProductCommandHandler: {@Request}", command);

      var product = command.Adapt<Product>();

      _session.Store(product);
      await _session.SaveChangesAsync(cancellationToken);

      return product.Adapt<CreateProductResponse>();
   }
}