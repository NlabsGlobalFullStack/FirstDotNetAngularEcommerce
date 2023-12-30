namespace eCommerceServer.WebApi.DTOs;

public sealed record AddProductDto(
    string Name,
    string Description,
    decimal Price,
    string CoverImageUrl
);
public sealed record UpdateProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string CoverImageUrl
);
public sealed record RemoveProductDto(Guid Id);