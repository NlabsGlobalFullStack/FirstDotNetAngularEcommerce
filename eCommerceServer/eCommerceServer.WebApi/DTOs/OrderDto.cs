namespace eCommerceServer.WebApi.DTOs;

public sealed record AddOrderDto(
    Guid UserId,
    Guid ProductId,
    int Quantity
);
public sealed record UpdateOrderDto(
    Guid Id,
    Guid UserId,
    Guid ProductId,
    int Quantity
);
public sealed record RemoveOrderDto(Guid Id);