using eCommerceServer.WebApi.DTOs;
using FluentValidation;

namespace eCommerceServer.WebApi.Validators;

public sealed class AddProductDtoValidator : AbstractValidator<AddProductDto>
{
    public AddProductDtoValidator()
    {
        RuleFor(u => u.Name).NotEmpty().NotNull();
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MinimumLength(6);
    }
}

public sealed class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(u => u.Name).NotEmpty().NotNull();
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MinimumLength(6);
    }
}
