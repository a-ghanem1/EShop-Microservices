using FluentValidation;

namespace Catalog.API.Features.Products.UpdateProduct;

public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}