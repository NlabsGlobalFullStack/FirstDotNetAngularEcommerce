namespace ECommerceServer.WebApi.DTOs;

public sealed record LoginDto(
    string UserNameOrEmail,
    string Password,
    bool RememberMe);

public sealed record RegisterDto(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password);

public sealed record LoginResponseDto(
    string AccessToken,
    Guid UserId);

public sealed record AddSellerDto(
    Guid UserId,
    string Title,
    string Description);

public sealed record FakeUsersDto(
    Guid userId,
    string firstName,
    string lastName,
    string email,
    bool isSeller);