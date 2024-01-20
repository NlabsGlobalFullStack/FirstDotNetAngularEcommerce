namespace ECommerceServer.WebApi.Models;

public sealed class ShoppingCart : BaseModel
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}
