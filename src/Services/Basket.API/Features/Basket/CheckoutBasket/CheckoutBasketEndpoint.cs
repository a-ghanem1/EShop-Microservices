
namespace Basket.API.Features.Basket.CheckoutBasket;

public class CheckoutBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
         app.MapPost("/basket/checkout", async (CheckoutBasketCommand command, ISender sender) =>
        {
            var response = await sender.Send(command);
            return Results.Ok(response);
        })
        .WithName("CheckoutBasket")
        .Produces<CheckoutBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Checkout Basket")
        .WithDescription("Checkout Basket");
    }
}