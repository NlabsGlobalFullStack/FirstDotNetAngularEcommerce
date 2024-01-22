namespace ECommerceServer.WebApi.Models;

public sealed class Transaction : BaseModel
{
    public Guid BuyerId { get; set; }
    public Guid SellerId { get; set; }
    public byte TransactionType { get; set; } = 0; // Sale Or Buy // Sale/Satış => 0 / Buy/Alış => 1
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public IEnumerable<TransactionDetail>? Details { get; set; }
}
