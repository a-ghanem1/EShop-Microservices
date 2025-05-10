namespace Basket.API.Features.Basket.CheckoutBasket;

public class CheckoutBasketCommand : ICommand<CheckoutBasketResponse>
{
    public BasketCheckoutDto BasketCheckoutDto { get; set; }
}