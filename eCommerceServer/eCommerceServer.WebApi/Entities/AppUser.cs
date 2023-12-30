namespace eCommerceServer.WebApi.Entities;

/// <summary>
/// Uygulama kullanıcılarını temsil eden Entity sınıfı.
/// </summary>
public sealed class AppUser  //Entity => Domain Driven Design
{
    /// <summary>
    /// Kullanıcının benzersiz kimliği.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Kullanıcının adı.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Kullanıcının soyadı.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Kullanıcının e-posta adresi.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Kullanıcının kullanıcı adı.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Kullanıcının şifresi.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    public bool IsAdmin { get; set; } = false;
}
