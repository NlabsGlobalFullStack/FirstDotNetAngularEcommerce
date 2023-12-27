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
        optionsBuilder.UseSqlServer("YourConnectionString");
    }

    /// <summary>
    /// Uygulama kullanıcılarına erişim sağlayan DbSet.
    /// </summary>
    public DbSet<AppUser> Users { get; set; }
}
