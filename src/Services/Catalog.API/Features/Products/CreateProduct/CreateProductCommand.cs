using BuildingBlocks.CQRS;

namespace Catalog.API.Features.Products.CreateProduct;

public class CreateProductCommand : ICommand<CreateProductResponse>
{
   public string Name { get; set; }
   public List<string> Categories { get; set; } = [];
   public string Description { get; set; }
   public string ImageFile { get; set; }
   public decimal Price { get; set; }
}