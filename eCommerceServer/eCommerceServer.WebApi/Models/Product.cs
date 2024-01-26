namespace ECommerceServer.WebApi.Models;

public sealed class Product : BaseModel
{
    public Guid SellerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? Keywords { get; set; } = string.Empty; // SEO Keys
    public string? Description { get; set; } = string.Empty; // SEO Description
    public decimal Price { get; set; }
    public string CoverImageUrl { get; set; } = string.Empty;
}
