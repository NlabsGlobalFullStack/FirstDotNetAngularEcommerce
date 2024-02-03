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
    private readonly ShoppingCartRepository _shoppingCartRepository;
    public ShoppingCartsController(ShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        IEnumerable<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetAllByUserId(userId);
        return Ok(shoppingCarts);
    }

    [HttpGet]
    public IActionResult Increment(Guid productId)
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        var result = _shoppingCartRepository.Increment(userId, productId);        
        return NoContent();
    }

    [HttpGet]
    public IActionResult Decrement(Guid productId)
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        var result = _shoppingCartRepository.Decrement(userId, productId);
        return NoContent();
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        var shoppingCart = _shoppingCartRepository.GetById(id);

        if (shoppingCart is not null)
        {
            var result = _shoppingCartRepository.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        return NoContent();
    }

    [HttpGet]
    public IActionResult Payment()
    {
        string userIdString = User.Claims.Single(s => s.Type == "UserId").Value;
        Guid userId = Guid.Parse(userIdString);

        var result = _shoppingCartRepository.Payment(userId);
        return NoContent();
    }
}
