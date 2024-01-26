using ECommerceServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.WebApi.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<AppUser>().HasIndex(u => u.UserName).IsUnique();

        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("money");
        modelBuilder.Entity<Product>().HasIndex(u => u.Name).IsUnique();


        List<Product> products = new();
        Product product1 = new()
        {
            SellerId = Guid.NewGuid(),
            Name = "Apple",
            Slug = "apple",
            Keywords = "apple, elma",
            Description = "Güzel Elma",
            Price = 20,
            CoverImageUrl = "apple.png"
        };
        products.Add(product1);

        Product product2 = new()
        {
            SellerId = Guid.NewGuid(),
            Name = "Pear",
            Slug = "pear",
            Price = 30,
            CoverImageUrl = "pear.png"
        };
        products.Add(product2);

        Product product3 = new()
        {
            SellerId = Guid.NewGuid(),
            Name = "Watermelon",
            Slug = "watermelon",
            Price = 120,
            CoverImageUrl = "watermelon.png"
        };
        products.Add(product3);

        Product product4 = new()
        {
            SellerId = Guid.NewGuid(),
            Name = "Banana",
            Slug = "banana",
            Price = 50,
            CoverImageUrl = "banana.png"
        };
        products.Add(product4);

        modelBuilder.Entity<Product>().HasData(products);
    }
}
