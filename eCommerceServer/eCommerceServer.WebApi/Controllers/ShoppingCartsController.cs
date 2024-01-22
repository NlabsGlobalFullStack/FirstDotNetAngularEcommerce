using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class ShoppingCartsController : ControllerBase
{
    private readonly ShoppingCartService _shoppingCartService;
    private readonly OrderService _orderService;

    public ShoppingCartsController(ShoppingCartService shoppingCartService, OrderService orderService)
    {
        _shoppingCartService = shoppingCartService;
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        IEnumerable<ShoppingCart> shoppingCarts = _shoppingCartService.GetAllByUserId(userId);
        return Ok(shoppingCarts);
    }

    [HttpGet]
    public IActionResult Increment(Guid productId)
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        ShoppingCart? shoppingCart = _shoppingCartService.GetByUserIdAndProductId(userId, productId);
    }
}
