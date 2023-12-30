using eCommerceServer.WebApi.Context;
using eCommerceServer.WebApi.Entities;

namespace eCommerceServer.WebApi.Repositories;

public class BasketRepository
{
    private readonly AppDbContext context;

    public BasketRepository()
    {
        context = new();
    }

    public void Add(Basket basket)
    {
        context.Baskets.Add(basket);
        context.SaveChanges();
    }

    public void Update(Basket basket)
    {
        context.Baskets.Update(basket);
        context.SaveChanges();
    }

    public void Remove(Basket basket)
    {
        context.Baskets.Remove(basket);
    }
}
