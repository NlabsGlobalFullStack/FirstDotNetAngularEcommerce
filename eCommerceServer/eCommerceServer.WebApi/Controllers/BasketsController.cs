using eCommerceServer.WebApi.Context;
using eCommerceServer.WebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class BasketsController : ControllerBase
{
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult GetAll()
    {
        AppDbContext context = new();
        List<Basket> orders = context.Baskets.ToList();
        return Ok(orders);
    }
}
