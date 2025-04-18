namespace Basket.API.Features.Basket.GetBasket;

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var query = new GetBasketQuery { UserName = userName };
            var response = await sender.Send(query);
            return Results.Ok(response);
        })
        .WithName("GetBasketByUserName")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get basket for a user")
        .WithDescription("Retrieves the basket (shopping cart) for the specified user.");
    }
}
