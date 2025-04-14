namespace Catalog.API.Features.Products.GetProducts;

public class GetProductsQuery : IQuery<GetProductsResponse>
{
   public int? PageNumber { get; set; } = 1;
   public int? PageSize { get; set; } = 10;
}