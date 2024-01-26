namespace ECommerceServer.WebApi.Models;

public sealed class Seller : BaseModel
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
}
