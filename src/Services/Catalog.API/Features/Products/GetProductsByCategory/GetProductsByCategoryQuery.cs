namespace Catalog.API.Features.Products.GetProductsByCategory;

public class GetProductsByCategoryQuery : IQuery<GetProductsByCategoryResponse>
{
    public string Category { get; set; }
}