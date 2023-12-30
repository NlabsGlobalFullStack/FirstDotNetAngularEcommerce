namespace eCommerceServer.WebApi.DTOs;

public sealed record AddBasketDto(
    Guid UserId,
    Guid ProductId,
    int Quantity
);
public sealed record UpdateBasketDto(
    Guid Id,
    Guid UserId,
    Guid ProductId,
    int Quantity
);
public sealed record RemoveBasketDto(Guid Id);
