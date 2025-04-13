namespace Catalog.API.Features.Products.GetProducts;

public class GetProductsResponse
{
    public IEnumerable<Product> Products { get; set; }
}