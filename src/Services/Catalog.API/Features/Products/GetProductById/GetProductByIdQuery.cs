namespace Catalog.API.Features.Products.GetProductById;

public class GetProductByIdQuery : IQuery<GetProductByIdResponse>
{
   public Guid Id { get; set; }
}