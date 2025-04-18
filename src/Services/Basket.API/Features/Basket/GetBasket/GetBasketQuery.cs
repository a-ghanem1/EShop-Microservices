using BuildingBlocks.CQRS;

namespace Basket.API.Features.Basket.GetBasket;

public class GetBasketQuery : IQuery<GetBasketResponse>
{
    public string UserName { get; set; }
}
