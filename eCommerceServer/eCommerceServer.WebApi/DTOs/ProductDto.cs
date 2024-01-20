namespace ECommerceServer.WebApi.DTOs;

public sealed record AddProductDto(
    Guid UserId,
    string Name,
    string Description,
    decimal Price,
    string CoverImageUrl);

public sealed record UpdateProductDto(
    Guid Id,
    Guid UserId,
    string Name,
    string Description,
    decimal Price,
    string CoverImageUrl);