
namespace Basket.API.Features.Basket.DeleteBasket;

public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResponse>
{
   private readonly IBasketRepository _basketRepository;
   public DeleteBasketCommandHandler(IBasketRepository basketRepository)
   {
      _basketRepository = basketRepository;
   }

   public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
   {
      // TODO: delete basket from database and cache       
      await _basketRepository.DeleteBasket(request.UserName, cancellationToken);

      return new DeleteBasketResponse
      {
         IsSuccess = true
      };
   }
}