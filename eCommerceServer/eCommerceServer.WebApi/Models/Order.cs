using ECommerceServer.WebApi.Enums;

namespace ECommerceServer.WebApi.Models;

public sealed class Order : BaseModel
{
    public Guid UserId { get; set; }
    public string Number { get; set; } = string.Empty;
    public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Onaylandi;
    public DateTime? ExpectedArrival { get; set; }
    public string? CargoCompany { get; set; }
    public string? CargoTrackingNumber { get; set; }
    public IEnumerable<OrderDetail>? Details { get; set; }
}
