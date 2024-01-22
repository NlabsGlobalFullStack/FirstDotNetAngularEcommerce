using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;

namespace ECommerceServer.WebApi.Services;

public sealed class ProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.OrderBy(p => p.CreatedDate).ToList();
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
            SellerId = request.UserId,
            Name = request.Name,
            Slug = slug,
            Description = request.Description,
            Price = request.Price,
            CoverImageUrl = request.CoverImageUrl
        };

        return product;
    }

    private Product UpdateProductFromRequest(UpdateProductDto request)
    {
        string slug = GenerateSlug(request.Name);

        var product = _context.Products.Find(request.Id);

        if (product != null)
        {
            product.SellerId = request.UserId;
            product.Name = request.Name;
            product.Slug = slug;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CoverImageUrl = request.CoverImageUrl;
        }

        return product;
    }

    public void Add(AddProductDto request)
    {
        Product product = CreateProductFromRequest(request);
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public bool IsNameExists(string name)
    {
        return _context.Products.Any(p => p.Name == name);
    }

    public void Update(UpdateProductDto request)
    {
        Product product = UpdateProductFromRequest(request);

        if (product != null)
        {
            _context.SaveChanges();
        }
    }
}
