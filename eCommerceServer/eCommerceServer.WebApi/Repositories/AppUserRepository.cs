using eCommerceServer.WebApi.Context;
using eCommerceServer.WebApi.Entities;

namespace eCommerceServer.WebApi.Repositories;

/// <summary>
/// Uygulama kullanıcılarına erişim sağlayan Repository sınıfı.
/// </summary>
public class AppUserRepository
{
    private readonly AppDbContext context;

    /// <summary>
    /// AppUserRepository sınıfının yapıcı metodu. Veritabanı bağlamını oluşturur.
    /// </summary>
    public AppUserRepository()
    {
        context = new();
    }

    /// <summary>
    /// Yeni bir kullanıcı ekler.
    /// </summary>
    /// <param name="user">Eklenecek kullanıcı.</param>
    public void Add(AppUser user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    /// <summary>
    /// Verilen e-posta ile bir kullanıcının varlığını kontrol eder.
    /// </summary>
    /// <param name="email">Kontrol edilecek e-posta adresi.</param>
    /// <returns>E-posta varsa true, aksi takdirde false.</returns>
    public bool IsEmailExists(string email)
    {
        return context.Users.Any(u => u.Email == email);
    }

    /// <summary>
    /// Verilen kullanıcı adıyla bir kullanıcının varlığını kontrol eder.
    /// </summary>
    /// <param name="userName">Kontrol edilecek kullanıcı adı.</param>
    /// <returns>Kullanıcı adı varsa true, aksi takdirde false.</returns>
    public bool IsUserNameExists(string userName)
    {
        return context.Users.Any(u => u.UserName == userName);
    }

    /// <summary>
    /// Verilen kullanıcı adı veya e-posta ve şifre ile bir kullanıcının oturum açmasını sağlar.
    /// </summary>
    /// <param name="userNameOrEmail">Kullanıcı adı veya e-posta adresi.</param>
    /// <param name="password">Kullanıcının şifresi.</param>
    /// <returns>Oturum açan kullanıcı, eğer varsa; aksi takdirde null.</returns>
    public AppUser? Login(string userNameOrEmail, string password)
    {
        return context.Users.FirstOrDefault(u => u.Email == userNameOrEmail || u.UserName == userNameOrEmail && u.Password == password);
    }
}
