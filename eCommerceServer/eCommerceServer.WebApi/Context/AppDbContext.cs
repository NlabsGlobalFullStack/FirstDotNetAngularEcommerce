using eCommerceServer.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerceServer.WebApi.Context;

/// <summary>
/// Uygulamanın veritabanı bağlamını temsil eden DbContext sınıfı.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// DbContext sınıfının yapılandırılmasını sağlar.
    /// </summary>
    /// <param name="optionsBuilder">DbContext seçenekleri için kullanılan seçenek oluşturucu.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Veritabanı bağlantı dizesini ayarla (Örnek: optionsBuilder.UseSqlServer("YourConnectionString");).
        optionsBuilder.UseSqlServer("Data Source=SERVER;Initial Catalog=IEAFullStackEcommerceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    /// <summary>
    /// Uygulama kullanıcılarına erişim sağlayan DbSet.
    /// </summary>
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<AppUser>().HasIndex(u => u.UserName).IsUnique();

        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("money");
        modelBuilder.Entity<Product>().HasIndex(u => u.Name).IsUnique();

        AppUser user = new()
        {
            Id = Guid.NewGuid(),
            FirstName = "Cuma",
            LastName = "KÖSE",
            Email = "turkmvc@gmail.com",
            UserName = "turkmvc",
            Password = "String123",
            IsAdmin = true
        };
        modelBuilder.Entity<AppUser>().HasData(user);

        List<Product> products = new();
        Product product1 = new()
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Name = "Elma",
            Slug = "elma",
            Price = 20,
            CoverImageUrl = "apple.png"
        };
        products.Add(product1);

        Product product2 = new()
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Name = "Armut",
            Slug = "armut",
            Price = 30,
            CoverImageUrl = "pear.png"
        };
        products.Add(product2);

        Product product3 = new()
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Name = "Karpuz",
            Slug = "karpuz",
            Price = 120,
            CoverImageUrl = "watermelon.png"
        };
        products.Add(product3);

        Product product4 = new()
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Name = "Muz",
            Slug = "muz",
            Price = 50,
            CoverImageUrl = "banana.png"
        };
        products.Add(product4);

        modelBuilder.Entity<Product>().HasData(products);
    }
}
