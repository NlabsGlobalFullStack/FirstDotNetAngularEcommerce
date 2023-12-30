using eCommerceServer.WebApi.Context;
using eCommerceServer.WebApi.DTOs;
using eCommerceServer.WebApi.Entities;
using System.Text.RegularExpressions;

namespace eCommerceServer.WebApi.Repositories;

public class ProductRepository
{
    private readonly AppDbContext context;
    public ProductRepository()
    {
        context = new();
    }

    private string GenerateSlug(string input)
    {
        string slug = input.ToLowerInvariant();
        slug = slug.Replace(" ", "-");
        slug = RemoveSpecialCharacters(slug);
        return slug;
    }

    private string RemoveSpecialCharacters(string input)
    {
        Regex regex = new Regex("[^a-z0-9]");
        return regex.Replace(input, "");
    }

    public Product CreateProductFromRequest(AddProductDto request)
    {
        string slug = GenerateSlug(request.Name);

        Product product = new Product()
        {
            Name = request.Name,
            Slug = slug,
            Description = request.Description,
            Price = request.Price,
            CoverImageUrl = request.CoverImageUrl
        };

        return product;
    }

    public void Add(AddProductDto request)
    {
        Product product = CreateProductFromRequest(request);
        Add(product);
    }

    public void Add(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public bool IsNameExists(string name)
    {
        return context.Products.Any(p => p.Name == name);
    }

    public void Update(Product product)
    {
        context.Products.Update(product);
        context.SaveChanges();
    }

    public void Remove(Product product)
    {
        context.Products.Remove(product);
    }
}
