namespace Basket.API.Features.Basket.StoreBasket;

public class StoreBasketCommand : ICommand<StoreBasketResponse>
{
   public ShoppingCart Cart { get; set; }
}