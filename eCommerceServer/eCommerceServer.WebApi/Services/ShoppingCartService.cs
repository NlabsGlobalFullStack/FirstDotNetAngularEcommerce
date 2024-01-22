using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.WebApi.Services;

public sealed class ShoppingCartService
{
    private readonly AppDbContext _context;

    public ShoppingCartService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ShoppingCart> GetAllByUserId(Guid userId)
    {
        return _context.ShoppingCarts
            .Where(s => s.UserId == userId)
            .Include(p => p.Product)
            .ToList();
    }

    public ShoppingCart? GetByUserIdAndProductId(Guid userId, Guid productId)
    {
        return _context.ShoppingCarts
            .Where(p => p.UserId == userId && p.ProductId == productId)
            .FirstOrDefault();
    }

    public ShoppingCart? GetById(Guid id)
    {
        return _context.ShoppingCarts.Find(id);
    }

    public void Add(ShoppingCart cart)
    {
        _context.ShoppingCarts.Add(cart);
        _context.SaveChanges();
    }

    public void Update(ShoppingCart cart)
    {
        _context.ShoppingCarts.Update(cart);
        _context.SaveChanges();
    }

    public void Remove(ShoppingCart cart)
    {
        _context.ShoppingCarts.Remove(cart);
        _context.SaveChanges();
    }

    public void RemoveRange(IEnumerable<ShoppingCart> carts)
    {
        _context.RemoveRange(carts);
        _context.SaveChanges();
    }
}
