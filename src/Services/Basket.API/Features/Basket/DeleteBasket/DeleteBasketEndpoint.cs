
namespace Basket.API.Features.Basket.DeleteBasket;

public class DeleteBasketEndpoint : ICarterModule
{
   public void AddRoutes(IEndpointRouteBuilder app)
   {
      app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
      {
         var command = new DeleteBasketCommand
         {
            UserName = userName
         };

         var response = await sender.Send(command);

         return Results.Ok(response);
      })
      .WithName("DeleteProduct")
      .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .ProducesProblem(StatusCodes.Status404NotFound)
      .WithSummary("Delete Product")
      .WithDescription("Delete Product");
   }
}