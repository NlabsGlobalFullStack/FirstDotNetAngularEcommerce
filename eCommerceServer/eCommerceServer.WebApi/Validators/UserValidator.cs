using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;
using FluentValidation;

namespace ECommerceServer.WebApi.Validators;

public sealed class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(u => u.UserNameOrEmail).NotEmpty().NotNull();
        RuleFor(p => p.Password).NotEmpty().MinimumLength(6).Matches("[a-z]").Matches("[A-Z]").Matches("[0-9]");
    }
}

public sealed class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.LastName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress().MinimumLength(3);
        RuleFor(p => p.UserName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.Password).Matches("[a-z]").Matches("[A-Z]").Matches("[0-9]").MinimumLength(6);
    }
}

public sealed class AddSellerDtoValidator : AbstractValidator<Seller>
{
    public AddSellerDtoValidator()
    {
        RuleFor(p => p.Title).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.Description).NotEmpty().NotNull().MinimumLength(3);
    }
}
