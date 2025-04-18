namespace Basket.API.Features.Basket.GetBasket;

public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResponse>
{
    private readonly IBasketRepository _basketRepository;
    public GetBasketQueryHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<GetBasketResponse> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var cart = await _basketRepository.GetBasket(request.UserName, cancellationToken);

        return new GetBasketResponse
        {
            Cart = cart
        };
    }
}