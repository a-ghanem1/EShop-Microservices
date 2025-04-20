
using Discount.Grpc;

namespace Basket.API.Features.Basket.StoreBasket;

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResponse>
{
   private readonly IBasketRepository _basketRepository;
   private readonly DiscountProtoService.DiscountProtoServiceClient _discountProto;

   public StoreBasketCommandHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discountProto)
   {
      _basketRepository = basketRepository;
      _discountProto = discountProto;
   }

   public async Task<StoreBasketResponse> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
   {
      await DeductDiscount(request.Cart, cancellationToken);

      await _basketRepository.StoreBasket(request.Cart, cancellationToken);

      return new StoreBasketResponse
      {
         UserName = request.Cart.UserName
      };
   }

   private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
   {
      foreach (var item in cart.Items)
      {
         var coupon = await _discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
         item.Price -= coupon.Amount;
      }
   }
}