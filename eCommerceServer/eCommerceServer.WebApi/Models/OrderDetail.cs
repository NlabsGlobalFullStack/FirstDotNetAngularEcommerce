namespace ECommerceServer.WebApi.Models;

public sealed class OrderDetail : BaseModel
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
