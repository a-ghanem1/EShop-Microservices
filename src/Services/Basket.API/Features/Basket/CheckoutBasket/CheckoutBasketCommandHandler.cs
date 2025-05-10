using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Features.Basket.CheckoutBasket;

public class CheckoutBasketCommandHandler
    (IBasketRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResponse>
{
    public async Task<CheckoutBasketResponse> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        // get existing basket with total price
        // Set totalprice on basketcheckout event message
        // send basket checkout event to rabbitmq using masstransit
        // delete the basket

        var basket = await repository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);
        if (basket == null)
        {
            return new CheckoutBasketResponse
            {
                IsSuccess = false,
            };
        }

        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        return new CheckoutBasketResponse
        {
            IsSuccess = true,
        };
    }
}