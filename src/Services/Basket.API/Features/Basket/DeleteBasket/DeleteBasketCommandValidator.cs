namespace Basket.API.Features.Basket.DeleteBasket;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
   public DeleteBasketCommandValidator()
   {
      RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
   }
}