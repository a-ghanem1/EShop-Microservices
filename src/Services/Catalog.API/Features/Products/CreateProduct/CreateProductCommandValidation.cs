using FluentValidation;

namespace Catalog.API.Features.Products.CreateProduct;

public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("Category are required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
