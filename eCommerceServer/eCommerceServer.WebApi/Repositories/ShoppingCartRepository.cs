using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.WebApi.Repositories;

public sealed class ShoppingCartRepository
{
    private readonly AppDbContext _context;
    private readonly OrderRepository _orderRepository;
    public ShoppingCartRepository(AppDbContext context, OrderRepository orderRepository)
    {
        _context = context;
        _orderRepository = orderRepository;
    }

    public class ShoppingCartOperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int Quantity { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
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

    public ShoppingCartOperationResult Delete(Guid id)
    {
        var shoppingCart = GetById(id);

        if (shoppingCart is not null)
        {
            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();

            return new ShoppingCartOperationResult { Success = true, Message = "Ürün sepetinizden kaldırıldı." };
        }

        return new ShoppingCartOperationResult { Success = false, ErrorMessage = "Ürün sepetinizde bulunamadı." };
    }


    public void RemoveRange(IEnumerable<ShoppingCart> carts)
    {
        _context.RemoveRange(carts);
        _context.SaveChanges();
    }

    internal ShoppingCartOperationResult Increment(Guid userId, Guid productId)
    {
        var shoppingCart = GetByUserIdAndProductId(userId, productId);

        if (shoppingCart is null)
        {
            shoppingCart = new()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = 1
            };
            Add(shoppingCart);
            return new ShoppingCartOperationResult { Success = true, Message = "Ürün sepetinize eklendi.", Quantity = shoppingCart.Quantity };
        }
        else
        {
            shoppingCart.Quantity++;
            Update(shoppingCart);
            return new ShoppingCartOperationResult { Success = true, Message = "Ürün miktarı artırıldı.", Quantity = shoppingCart.Quantity };
        }
    }

    internal ShoppingCartOperationResult Decrement(Guid userId, Guid productId)
    {
        var shoppingCart = GetByUserIdAndProductId(userId, productId);

        if (shoppingCart is not null)
        {
            shoppingCart.Quantity--;

            if (shoppingCart.Quantity == 0)
            {
                Remove(shoppingCart);
                return new ShoppingCartOperationResult { Success = true, Message = "Ürün sepetinizden kaldırıldı.", Quantity = 0 };
            }
            else
            {
                Update(shoppingCart);
                return new ShoppingCartOperationResult { Success = true, Message = "Ürün miktarı azaltıldı.", Quantity = shoppingCart.Quantity };
            }
        }
        return new ShoppingCartOperationResult { Success = false, ErrorMessage = "Ürün sepetinizde bulunamadı." };
    }


    public IEnumerable<ShoppingCart> Payment(Guid userId)
    {
        var carts = GetAllByUserId(userId);

        if (carts.Any())
        {
            Order order = new()
            {
                Number = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                UserId = userId
            };

            List<OrderDetail> details = new List<OrderDetail>();

            foreach (var cart in carts)
            {
                if (cart.Product != null)
                {
                    OrderDetail orderDetail = new()
                    {
                        Price = cart.Product.Price,
                        SellerId = cart.Product.SellerId,
                        Quantity = cart.Quantity,
                        ProductId = cart.ProductId,
                    };

                    details.Add(orderDetail);
                }
            }

            order.Details = details;

            _orderRepository.Add(order);
            RemoveRange(carts);
        }
        return carts;
    }
}
