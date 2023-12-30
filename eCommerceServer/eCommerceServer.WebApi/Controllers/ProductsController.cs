using eCommerceServer.WebApi.Context;
using eCommerceServer.WebApi.Entities;
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
}
