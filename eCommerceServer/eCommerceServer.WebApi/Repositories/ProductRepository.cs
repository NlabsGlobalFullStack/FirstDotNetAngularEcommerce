using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;

namespace ECommerceServer.WebApi.Repositories;
public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    //Dashboard & Home
    public List<Product> GetAll()
    {
        var result = _context.Products.OrderByDescending(p => p.CreatedDate).ToList();
        if (result is null)
        {
            throw new ArgumentException("Sistemde Kayıtlı ürün bulunamadı!");
        }
        else
        {
            return result;
        }
    }

    //Home Is Login
    public List<Product> IsLoginGetAll(Guid userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            var seller = _context.Sellers.FirstOrDefault(s => s.UserId == user.Id);
            if (seller is not null)
            {
                var result = _context.Products
                    .Where(p => p.SellerId != seller.Id)
                    .OrderByDescending(p => p.CreatedDate)
                    .ToList();
                return result;
            }
            else
            {
                var result = _context.Products
                    .OrderByDescending(p => p.CreatedDate)
                    .ToList();
                return result;
            }
        }
        else
        {
            // Kullanıcı bulunamadı durumu
            throw new ArgumentException("Kullanıcı bulunamadı!");
        }
    }



    //Seller
    public List<Product>? GetByUserId(Guid userId)
    {
        var isSeller = _context.Users.Any(u => u.Id == userId && u.IsSeller == true);
        var user = _context.Users?.Where(u => u.Id == userId).FirstOrDefault();
        var seller = _context.Sellers?.Where(s => s.UserId == user.Id).FirstOrDefault();
        var result = _context.Products?.Where(p => p.SellerId == seller.Id).ToList();       

        if (isSeller)
        {
            if (result is null)
            {
                throw new ArgumentException("Henüz sisteme ürün kaydetmediniz!");
            }
            else
            {
                return result;
            }
        }
        else
        {
            throw new ArgumentException("Lütfen Satıcı Olmak İçin Talep Gönderiniz!");
        }
    }

    private string GenerateSlug(string input)
    {
        string slug = input.ToLowerInvariant();
        slug = slug.Replace(" ", "-");
        return slug;
    }

    private Product CreateProductFromRequest(AddProductDto request)
    {
        string slug = GenerateSlug(request.Name);

        Product product = new Product()
        {
            SellerId = request.SellerId,
            Name = request.Name,
            Slug = slug,
            Keywords = request.Keywords,
            Description = request.Description,
            Price = request.Price,
            CoverImageUrl = request.CoverImageUrl
        };
        _context.Products.Add(product);
        _context.SaveChanges();

        return product;
    }

    private Product UpdateProductFromRequest(UpdateProductDto request)
    {
        string slug = GenerateSlug(request.Name);

        var product = _context.Products.Find(request.Id);

        if (product is null)
        {
            product.SellerId = request.SellerId;
            product.Name = request.Name;
            product.Slug = slug;
            product.Keywords = request.Keywords;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CoverImageUrl = request.CoverImageUrl;
        }

        return product;
    }

    public void Add(AddProductDto request)
    {
        var result = _context.Sellers.Any(u => u.UserId == request.SellerId && u.IsActive == true);
        if (result)
        {
            Product product = CreateProductFromRequest(request);
        }
    }

    public bool IsNameExists(string name)
    {
        return _context.Products.Any(p => p.Name == name);
    }

    public void Update(UpdateProductDto request)
    {
        var result = _context.Users.Any(u => u.Id == request.SellerId && u.IsSeller == true);
        if (result)
        {
            Product product = UpdateProductFromRequest(request);

            if (product != null)
            {
                _context.SaveChanges();
            }
        }
    }
}
