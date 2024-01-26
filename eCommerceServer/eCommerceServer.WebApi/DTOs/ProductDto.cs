namespace ECommerceServer.WebApi.DTOs;

public sealed record AddProductDto(
    Guid SellerId,
    string Name,
    string Keywords,
    string Description,
    decimal Price,
    string CoverImageUrl);

public sealed record UpdateProductDto(
    Guid Id,
    Guid SellerId,
    string Name,
    string Keywords,
    string Description,
    decimal Price,
    string CoverImageUrl);