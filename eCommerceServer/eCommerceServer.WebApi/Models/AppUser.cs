namespace ECommerceServer.WebApi.Models;

public sealed class AppUser : BaseModel
{
    public bool IsAdmin { get; set; } = false;
    public bool IsSeller { get; set; } = false;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public byte[] PasswordSalt { get; set; } = new byte[64];
    public byte[] PasswordHash { get; set; } = new byte[128];
    public IEnumerable<Product>? Products { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}
