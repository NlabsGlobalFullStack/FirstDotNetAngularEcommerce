using AutoMapper;
using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Validators;
using FluentValidation.Results;

namespace ECommerceServer.WebApi.Services;

public class AuthenticationException : Exception
{
    public int StatusCode { get; }
    public string ErrorMessage { get; }

    public AuthenticationException(int statusCode, string errorMessage, List<string> errorMessages) : base(errorMessage)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }

    public AuthenticationException(string? message) : base(message)
    {
        ErrorMessage = message;
    }

    public List<string> ErrorMessages { get; }
}


public sealed class AuthService
{
    private readonly AppDbContext _context;
    private readonly JwtProvider _jwtProvider;
    private readonly IMapper _mapper;

    public AuthService(AppDbContext context, IMapper mapper, JwtProvider jwtProvider)
    {
        _context = context;
        _mapper = mapper;
        _jwtProvider = jwtProvider;
    }

    public void Register(RegisterDto request)
    {
        CheckValidation(request);

        CheckUserNameAndEmailIsExists(request);

        byte[] passwordSalt, passwordHash;
        PasswordService.CreatePassword(request.Password, out passwordSalt, out passwordHash);

        AppUser user = _mapper.Map<AppUser>(CreateUser(request, passwordSalt, passwordHash));

        CreatingUserToDatabase(user);
    }

    public LoginResponseDto Login(LoginDto request)
    {

        CheckValidation(request);

        AppUser? user = _context.Users.FirstOrDefault(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail);

        var validator = new LoginDtoValidator();
        var result = validator.Validate(request);

        UserIsNull(user, result);
        CheckPasswordIsTrue(request, user);

        string token = _jwtProvider.CreateToken(user, request.RememberMe);
        return new LoginResponseDto(token, user.Id);
    }

    private void UserIsNull(AppUser? user, ValidationResult result)
    {
        if (user is null)
        {
            List<string> errorMessages = result.Errors.Select(s => s.ErrorMessage).ToList();

            throw new AuthenticationException(422, "Kullanıcı bulunamadı veya geçersiz giriş bilgileri.", errorMessages);
        }
    }

    private void CheckPasswordIsTrue(LoginDto request, AppUser? user)
    {
        var validator = new LoginDtoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(s => s.ErrorMessage).ToList();

            throw new AuthenticationException(422, "Validation failed", errorMessages);
        }

        var checkPasswordIsTrue = PasswordService.CheckPassword(user, request.Password);

        if (!checkPasswordIsTrue)
        {
            // Logging
            //_logger.LogError("Invalid password");

            throw new AuthenticationException(422, "Invalid password", new List<string> { "Invalid password" });
        }
    }

    private void CreatingUserToDatabase(AppUser user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    private AppUser CreateUser(RegisterDto request, byte[] passwordSalt, byte[] passwordHash)
    {
        return new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.UserName,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash
        };
    }

    private void CheckUserNameAndEmailIsExists(RegisterDto request)
    {
        var checkUserNameIsExsists = _context.Users.Any(p => p.UserName == request.UserName);
        if (checkUserNameIsExsists)
        {
            throw new AuthenticationException(422, "Bu kullanıcı adı daha önce kullanılmış", new List<string> { "Bu kullanıcı adı daha önce kullanılmış" });
        }

        var checkEmailIsExists = _context.Users.Any(p => p.Email == request.Email);
        if (checkEmailIsExists)
        {
            throw new AuthenticationException(422, "Bu mail adresi daha önce kullanılmış", new List<string> { "Bu mail adresi daha önce kullanılmış" });
        }
    }

    private void CheckValidation(RegisterDto request)
    {
        var validator = new RegisterDtoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(s => s.ErrorMessage).ToList();
            throw new ArgumentException(string.Join(", ", errorMessages));
        }
    }

    private void CheckValidation(LoginDto request)
    {
        var validator = new LoginDtoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(s => s.ErrorMessage).ToList();
            throw new AuthenticationException(string.Join(", ", errorMessages));
        }
    }
}