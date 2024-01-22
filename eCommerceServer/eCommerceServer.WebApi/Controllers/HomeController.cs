using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        IEnumerable<Product> products = _productService.GetAll();
        return Ok(products);
    }
}
