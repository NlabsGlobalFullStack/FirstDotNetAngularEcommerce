using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        _authService.Register(request);

        return NoContent();
    }

    [HttpPost]
    public IActionResult Login(LoginDto reques) 
    {
        var response = _authService.Login(reques);
        return Ok(response);
    }
}
