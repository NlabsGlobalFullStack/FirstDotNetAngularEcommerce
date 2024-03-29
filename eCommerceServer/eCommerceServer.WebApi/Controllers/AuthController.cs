﻿using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserRepository _authService;

    public AuthController(UserRepository authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        try
        {
            _authService.Register(request);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(422, ex.Message);
        }
        catch
        {
            // Loglama yapılabilir
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    public IActionResult Login(LoginDto reques) 
    {
        try
        {
            var response = _authService.Login(reques);
            return Ok(response);
        }
        catch (AuthenticationException ex)
        {
            return StatusCode(422, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error" + ex.Message);
        }
    }
}
