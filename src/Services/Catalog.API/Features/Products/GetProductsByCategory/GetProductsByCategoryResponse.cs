namespace Catalog.API.Features.Products.GetProductsByCategory;

public class GetProductsByCategoryResponse
{
    public IEnumerable<Product> Products { get; set; }
}