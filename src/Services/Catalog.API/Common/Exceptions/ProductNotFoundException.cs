using BuildingBlocks.Exceptions;

namespace Catalog.API.Common.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid Id) : base("Product", Id)
    {
    }
}