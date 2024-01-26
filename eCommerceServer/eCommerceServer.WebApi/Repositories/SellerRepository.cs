using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;

namespace ECommerceServer.WebApi.Repositories;

public sealed class SellerRepository
{
    private readonly AppDbContext _context;

    public SellerRepository(AppDbContext context)
    {
        _context = context;
    }

    internal Seller Add(AddSellerDto request)
    {
        var result = _context.Sellers.Any(p => p.UserId == request.UserId);
        if (!result)
        {
            Seller seller = new()
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
            };
            _context.Sellers.Add(seller);
            _context.SaveChanges();
            return seller;
        }
        else
        {
            throw new ArgumentException("Bu kullanıcı daha önce satıcı olarak kaydedildi!");
        }
    }

    internal List<Seller> GetAddedSellerRequest()
    {
        var result = _context.Sellers.Where(s => s.IsActive == false).ToList();
        return result;
    }

    internal bool SellerActive(Guid sellerId)
    {
        var result = _context.Sellers.Any(s => s.UserId == sellerId && s.IsActive == false);
        AppUser? user = _context.Users.Where(u => u.Id == sellerId).FirstOrDefault();
        Seller? seller = _context.Sellers.Where(s => s.UserId == sellerId).FirstOrDefault();
        if (result)
        {
            if (user is null)
            {
                throw new ArgumentException("Böyle bir kullanıcı bulunmuyor!");
            }
            else
            {
                user.IsSeller = true;
                _context.Users.Update(user);
            }
            if (seller is null)
            {
                throw new ArgumentException("Böyle bir kullanıcı bulunmuyor!");
            }
            else
            {
                seller.IsActive = true;
                _context.Sellers.Update(seller);
            }
            _context.SaveChanges();
            return result;
        }
        else
        {
            throw new ArgumentException("Böyle bir kullanıcı bulunmuyor");
        }
    }
}
