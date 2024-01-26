using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.WebApi.Repositories;

public class OrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context =context;
    }

    public List<Order> GetAll()
    {
        var result = _context.Orders
            .OrderByDescending(o => o.CreatedDate)
            .Include(od => od.Details)!
            .ToList();

        if (result is null)
        {
            throw new ArgumentException("Sistemde Kayıtlı sipariş bulunamadı!");
        }
        else
        {
            return result;
        }
    }

    public List<Order> GetAllByUserId(Guid userId)
    {
        var result = _context.Orders
            .Where(o => o.UserId == userId)
            .Include(p => p.Details)!
            .ThenInclude(p => p.Product)
            .OrderByDescending(p => p.Id)
        .ToList();

        if (result is null)
        {
            throw new ArgumentException("Henüz bir sipariş oluşturmadınız");
        }
        else
        {
            return result;
        }
    }

    public List<OrderDetail> GetAllBySellerId(Guid userId)
    {
        var result = _context.OrderDetails
            .Where(o => o.SellerId == userId)
            .Include(p => p.Product)!
            .OrderByDescending(p => p.Id)
        .ToList();
        if (result is null)
        {
            throw new ArgumentException("Henüz Bir Sipariş Mevcut Degil");
        }
        else
        {
            return result;
        }
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public OrderDetail GetOrderDetail(Guid Id)
    {
        var result = _context.OrderDetails.Where(o => o.Id == Id).FirstOrDefault();


        if (result is null)
        {
            throw new ArgumentException("Ürün bulunamadı");
        }
        else
        {
            return result;
        }
    }
}
