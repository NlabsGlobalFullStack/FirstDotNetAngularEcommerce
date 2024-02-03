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
    public IActionResult GetProducts()
    {
        var result = _productRepository.GetAll();
        return Ok(new { statusCode = 200, count = result.Count, products = result });
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var result = _orderRepository.GetAll();
        return Ok(new { statusCode = 200, count = result.Count, orders = result });
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var result = _userRepository.GetAll();
        return Ok(new { statusCode = 200, count = result.Count, users = result });
    }

    [HttpGet]
    public IActionResult GetAddedSellerRequests()
    {
        var result = _sellerRepository.GetAddedSellerRequest();
        return Ok(new { statusCode = 200, count = result.Count, sellers = result });
    }

    [HttpPost]
    public IActionResult AddSeller(Guid userId)
    {
        var result = _sellerRepository.SellerActive(userId);
        return Ok(new { statusCode = 200, seller = result });
    }
}
