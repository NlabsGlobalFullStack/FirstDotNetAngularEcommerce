using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;
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
        IEnumerable<Product> products = _productService.GetAll();
        return Ok(products);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public IActionResult AddSeller(AddSellerDto request)
    {
        try
        {
            var result = _sellerRepository.Add(request);
            return Ok(new { statusCode = 200, message = result.Title });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
