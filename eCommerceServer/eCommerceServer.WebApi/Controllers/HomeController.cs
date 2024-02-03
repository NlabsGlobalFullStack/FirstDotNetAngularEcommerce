using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly ProductRepository _productService;
    private readonly SellerRepository _sellerRepository;

    public HomeController(ProductRepository productRepository, SellerRepository sellerRepository)
    {
        _productService = productRepository;
        _sellerRepository = sellerRepository;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var result = _productService.GetAll();
        return Ok(new { statusCode = 200, count = result.Count, products = result });
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public IActionResult IsLoginGetProducts(Guid userId)
    {
        var result = _productService.IsLoginGetAll(userId);
        return Ok(new { statusCode = 200, count = result.Count, products = result });
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public IActionResult MeAddSellerList(AddSellerDto request)
    {
        var result = _sellerRepository.Add(request);
        return Ok(new { statusCode = 200, message = result.Title });
    }
}
