using eCommerceServer.WebApi.Context;
using eCommerceServer.WebApi.Entities;

namespace eCommerceServer.WebApi.Repositories;

public class OrderRepository
{
    private readonly AppDbContext context;

    public OrderRepository()
    {
        context = new();
    }

    public void Add(Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
    }

    public void Update(Order order)
    {
        context.Orders.Update(order);
        context.SaveChanges();
    }

    public void Remove(Order order)
    {
        context.Orders.Remove(order);
    }
}
