namespace Basket.API.Features.Basket.DeleteBasket;

public class DeleteBasketCommand : ICommand<DeleteBasketResponse>
{
   public string UserName { get; set; }
}