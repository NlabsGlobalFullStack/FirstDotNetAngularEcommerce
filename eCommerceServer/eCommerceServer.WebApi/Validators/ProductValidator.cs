using ECommerceServer.WebApi.DTOs;
using FluentValidation;

namespace ECommerceServer.WebApi.Validators;

public sealed class AddProductDtoValidator : AbstractValidator<AddProductDto>
{
    public AddProductDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(3);
    }
}


public sealed class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(3);
    }
}