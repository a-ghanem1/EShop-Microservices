
namespace Basket.API.Features.Basket.StoreBasket;

public class StoreBasketEndpoint : ICarterModule
{
   public void AddRoutes(IEndpointRouteBuilder app)
   {
      app.MapPost("/basket", async (StoreBasketCommand request, ISender sender) =>
      {
         var response = await sender.Send(request);
         return Results.Created($"/basket/{response.UserName}", response);
      })
      .WithName("CreateProduct")
      .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .WithSummary("Create Product")
      .WithDescription("Create Product");
   }
}