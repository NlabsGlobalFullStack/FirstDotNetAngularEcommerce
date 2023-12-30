using eCommerceServer.WebApi.Context;
using eCommerceServer.WebApi.DTOs;
using eCommerceServer.WebApi.Entities;
using eCommerceServer.WebApi.Repositories;
using eCommerceServer.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProductsController : ControllerBase
{
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult GetAll()
    {
        AppDbContext context = new();
        List<Product> products = context.Products.ToList();
        return Ok(products);
    }

    [HttpPost]
    public IActionResult Add(AddProductDto request)
    {
        AddProductDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
        }

        ProductRepository productRepository = new();

        bool isNameExist = productRepository.IsNameExists(request.Name);
        if (isNameExist)
        {
            return BadRequest(new { Message = "product with this name is registered in the system, please try another name!" });
        }
        productRepository.CreateProductFromRequest(request);
        return NoContent();
    }
}
