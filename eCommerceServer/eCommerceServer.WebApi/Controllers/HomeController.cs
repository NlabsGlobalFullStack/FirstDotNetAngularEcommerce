using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly ProductRepository _productService;

    public HomeController(ProductRepository productRepository)
    {
        _productService = productRepository;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        IEnumerable<Product> products = _productService.GetAll();
        return Ok(products);
    }
}
