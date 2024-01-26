using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Services;
using ECommerceServer.WebApi.Validators;
using FluentValidation.Results;
using System.Security.Authentication;

namespace ECommerceServer.WebApi.Repositories;

public class UserRepository
{
    private readonly AppDbContext _context;
    private readonly JwtProvider _jwtProvider;

    public UserRepository(AppDbContext context, JwtProvider jwtProvider)
    {
        _context = context;
        _jwtProvider = jwtProvider;
    }
    
    //Dashboard
    public List<FakeUsersDto> GetAll()
    {
        var result = _context.Users
            .Where(u => u.IsAdmin == false)
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        if (result.Count <= 0)
        {
            throw new ArgumentException("Sistemde kayıtlı kullanıcı bulunmuyor");
        }
        else
        {
            List<FakeUsersDto> results = new List<FakeUsersDto>();
            foreach (var item in result)
            {
                var newResult = new FakeUsersDto(
                    userId: item.Id,
                    email: item.Email,
                    firstName: item.FirstName,
                    lastName: item.LastName,
                    isSeller: item.IsSeller
                );
                results.Add(newResult);
            }
            return results;
        }
    }



    //Authentication
    public void Register(RegisterDto request)
    {
        CheckValidation(request);

        CheckUserNameAndEmailIsExists(request);

        byte[] passwordSalt, passwordHash;
        PasswordService.CreatePassword(request.Password, out passwordSalt, out passwordHash);

        AppUser user = CreateUser(request, passwordSalt, passwordHash);
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

            throw new AuthenticationException("Kullanıcı bulunamadı veya geçersiz giriş bilgileri.");
        }
    }

    private void CheckPasswordIsTrue(LoginDto request, AppUser? user)
    {
        var validator = new LoginDtoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(s => s.ErrorMessage).ToList();

            throw new AuthenticationException("Validation failed");
        }

        var checkPasswordIsTrue = PasswordService.CheckPassword(user, request.Password);

        if (!checkPasswordIsTrue)
        {

            throw new AuthenticationException("Invalid password");
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
            throw new AuthenticationException("Bu kullanıcı adı daha önce kullanılmış");
        }

        var checkEmailIsExists = _context.Users.Any(p => p.Email == request.Email);
        if (checkEmailIsExists)
        {
            throw new AuthenticationException("Bu mail adresi daha önce kullanılmış");
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
