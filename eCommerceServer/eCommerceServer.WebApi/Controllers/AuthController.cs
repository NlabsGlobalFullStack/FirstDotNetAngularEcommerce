using AutoMapper;
using eCommerceServer.WebApi.DTOs;
using eCommerceServer.WebApi.Entities;
using eCommerceServer.WebApi.Repositories;
using eCommerceServer.WebApi.Services;
using eCommerceServer.WebApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceServer.WebApi.Controllers;

/// <summary>
/// Kimlik doğrulama işlemlerini yöneten controller sınıfı.
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// AuthController sınıfının yapıcı metodu.
    /// </summary>
    /// <param name="mapper">Object-to-object mapping işlemlerini sağlayan AutoMapper.</param>
    public AuthController(IMapper mapper, IConfiguration configuration)
    {
        _mapper = mapper;
        _configuration = configuration;
    }

    /// <summary>
    /// Kullanıcı kaydı işlemini gerçekleştiren HTTP POST metodu.
    /// </summary>
    /// <param name="request">Kayıt için kullanılan DTO.</param>
    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        // DTO doğrulamasını gerçekleştirir.
        RegisterDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        // Kullanıcı repository'si oluşturulur.
        AppUserRepository userRepository = new();

        // E-posta adresinin sistemde kayıtlı olup olmadığını kontrol eder.
        bool isEmailExist = userRepository.IsEmailExists(request.Email);
        if (isEmailExist)
        {
            return BadRequest(new { Message = "E-mail address Try Another E-Mail Address Registered in the System!" });
        }

        // Kullanıcı adının sistemde kayıtlı olup olmadığını kontrol eder.
        bool isUserNameExist = userRepository.IsUserNameExists(request.UserName);
        if (isUserNameExist)
        {
            return BadRequest(new { Message = "Username is Registered in the System. Try Another Username!" });
        }

        // DTO'dan AppUser nesnesine veri aktarımını gerçekleştirir.
        AppUser appUser = _mapper.Map<AppUser>(request);

        // Kullanıcıyı ekler.
        userRepository.Add(appUser);

        return NoContent();
    }

    /// <summary>
    /// Kullanıcı girişi işlemini gerçekleştiren HTTP POST metodu.
    /// </summary>
    /// <param name="request">Giriş için kullanılan DTO.</param>
    [HttpPost]
    public IActionResult Login(LoginDto request)
    {
        // DTO doğrulamasını gerçekleştirir.
        LoginDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        // Kullanıcı repository'si oluşturulur.
        AppUserRepository userRepository = new();

        // Kullanıcı adı veya e-posta ve şifre ile oturum açma işlemini gerçekleştirir.
        AppUser? user = userRepository.Login(request.UserNameOrEmail, request.Password);

        if (user is null)
        {
            return BadRequest(new { Message = "User Not Found!" });
        }

        JwtProvider jwtProvider = new(_configuration);
        string token = jwtProvider.CreateToken(user);
        return Ok(new {AccessToken = token});
    }
}
