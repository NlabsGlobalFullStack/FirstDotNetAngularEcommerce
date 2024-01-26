using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize( AuthenticationSchemes = "Bearer")]
public class DashboardController : ControllerBase
{
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;
    private readonly UserRepository _userRepository;
    private readonly SellerRepository _sellerRepository;

    public DashboardController(ProductRepository productRepository, OrderRepository orderRepository, UserRepository userRepository, SellerRepository sellerRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _sellerRepository = sellerRepository;
    }

    [HttpGet]
    public IActionResult GetProducts(Guid? userId)
    {
        var result = _productRepository.GetAll();
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var result = _orderRepository.GetAll();
        
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        try
        {
            var result = _userRepository.GetAll();
            return Ok(new { statusCode = 200, count = result.Count, users = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAddedSellerRequests()
    {
        try
        {
            var result = _sellerRepository.GetAddedSellerRequest();
            return Ok(new { statusCode = 200, count = result.Count, sellers = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult AddSeller(Guid userId)
    {
        try
        {
            var result = _sellerRepository.SellerActive(userId);
            return Ok(new { statusCode = 200, seller = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
