namespace ECommerceServer.WebApi.Models;

public class Seller : BaseModel
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public IEnumerable<Product> Products { get; set; }
}
