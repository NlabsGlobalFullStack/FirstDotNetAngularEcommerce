namespace eCommerceServer.WebApi.DTOs;

/// <summary>
/// Kullanıcının giriş bilgilerini temsil eden DTO sınıfı.
/// </summary>
public sealed record LoginDto(
    string UserNameOrEmail,
    string Password);

/// <summary>
/// Kullanıcının kayıt bilgilerini temsil eden DTO sınıfı.
/// </summary>
public sealed record RegisterDto(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password);
