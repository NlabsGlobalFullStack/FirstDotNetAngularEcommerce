namespace ECommerceServer.WebApi.Models;

public sealed class TransactionDetail : BaseModel
{
    public Guid TransactionId { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public decimal Amount { get; set; }
}
