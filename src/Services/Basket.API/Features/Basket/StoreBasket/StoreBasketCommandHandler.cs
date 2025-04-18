
namespace Basket.API.Features.Basket.StoreBasket;

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResponse>
{
   private readonly IBasketRepository _basketRepository;
   public StoreBasketCommandHandler(IBasketRepository basketRepository)
   {
      _basketRepository = basketRepository;
   }

   public async Task<StoreBasketResponse> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
   {
      //TODO: store basket in database (use Marten upsert - if exist = update, if not exist = insert)
      //TODO: update cache
      await _basketRepository.StoreBasket(request.Cart, cancellationToken);

      return new StoreBasketResponse
      {
         UserName = request.Cart.UserName
      };
   }
}