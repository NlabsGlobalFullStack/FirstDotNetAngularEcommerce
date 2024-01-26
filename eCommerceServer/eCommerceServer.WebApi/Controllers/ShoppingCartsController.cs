using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class ShoppingCartsController : ControllerBase
{
    private readonly ShoppingCartRepository _shoppingCartService;

    private readonly OrderRepository _orderService;
    public ShoppingCartsController(ShoppingCartRepository shoppingCartService, OrderRepository orderService)
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

        if (shoppingCart is null)
        {
            shoppingCart = new() 
            {
                UserId = userId,
                ProductId = productId,
                Quantity = 1
            };
            _shoppingCartService.Add(shoppingCart);
        }
        else
        {
            shoppingCart.Quantity++;
            _shoppingCartService.Update(shoppingCart);
        }
        return NoContent();
    }

    [HttpGet]
    public IActionResult Decrement(Guid productId)
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        ShoppingCart? shoppingCart = _shoppingCartService.GetByUserIdAndProductId(userId, productId);
        if (shoppingCart is not null)
        {
            shoppingCart.Quantity--;

            if (shoppingCart.Quantity == 0)
            {
                _shoppingCartService.Remove(shoppingCart);
            }
            else
            {
                _shoppingCartService.Update(shoppingCart);
            }
        }

        return NoContent();
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        ShoppingCart? shoppingCart = _shoppingCartService.GetById(id);
        if (shoppingCart is not null)
        {
            _shoppingCartService.Remove(shoppingCart);
        }

        return NoContent();
    }

    [HttpGet]
    public IActionResult Pay()
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        IEnumerable<ShoppingCart> carts = _shoppingCartService.GetAllByUserId(userId);

        Order order = new()
        {
            Number = Guid.NewGuid().ToString(),
            Date = DateTime.Now,
            UserId = userId
        };

        List<OrderDetail> details = new List<OrderDetail>();

        foreach (var cart in carts)
        {
            OrderDetail orderDetail = new()
            {
                Price = cart.Product!.Price,
                SellerId = cart.Product.SellerId,
                Quantity = cart.Quantity,
                ProductId = cart.ProductId,
            };

            details.Add(orderDetail);
        }

        order.Details = details;

        _orderService.Add(order);
        _shoppingCartService.RemoveRange(carts);

        return NoContent();
    }
}
