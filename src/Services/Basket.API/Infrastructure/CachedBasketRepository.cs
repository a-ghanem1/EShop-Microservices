using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Infrastructure;

public class CachedBasketRepository : IBasketRepository
{
    private readonly IBasketRepository _repository;
    private readonly IDistributedCache _cache;

    public CachedBasketRepository(IBasketRepository repository, IDistributedCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var cachedBasket = await _cache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(cachedBasket))
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;

        var basket = await _repository.GetBasket(userName, cancellationToken);

        if (basket is not null)
        {
            await _cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
            return basket;
        }

        return new ShoppingCart(userName);
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
    {
        await _cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

        await _repository.StoreBasket(basket, cancellationToken);

        return basket;

    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
    {
        await _repository.DeleteBasket(userName, cancellationToken);

        await _cache.RemoveAsync(userName, cancellationToken);

        return true;
    }
}
