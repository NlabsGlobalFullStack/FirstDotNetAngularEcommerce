using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Validators;

namespace ECommerceServer.WebApi.Services;

public sealed class AuthService
{
    private readonly AppDbContext _context;
    private readonly JwtProvider _jwtProvider;

    public AuthService(JwtProvider jwtProvider, AppDbContext context)
    {
        _context = context;
        _jwtProvider = jwtProvider;
    }

    public void Register(RegisterDto request)
    {
        #region Validation Check
        CheckValidation(request);
        #endregion

        #region UserName Or EMail Exists Control
        CheckUserNameAndEmailIsExists(request);
        #endregion

        #region Create Password
        byte[] passwordSalt, passwordHash;
        PasswordService.CreatePassword(request.Password, out passwordSalt, out passwordHash);
        #endregion

        #region Create User Object
        AppUser user = CreateUser(request, passwordSalt, passwordHash);
        #endregion

        #region User Save To Database
        CreatingUserToDatabase(user);
        #endregion
    }

    public LoginResponseDto Login( LoginDto request)
    {
        #region Validation Check
        CheckValidation(request);
        #endregion

        //immutable => bir defa set edilip bir daha değiştirilemeyen nesnelere denir
        // immutable => "It refers to objects that are set once and cannot be changed thereafter."

        #region Immutable One Set After Not Updated Object 
        AppUser? user = _context.Users.FirstOrDefault(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail);
        #endregion

        #region if User Is Null Business Logic
        if (user is null)
        {
            throw new ArgumentException("User Not Found");
        }

        var checkPasswordIsTrue = PasswordService.CheckPassword(user, request.Password);
        if (!checkPasswordIsTrue)
        {
            throw new ArgumentException("password information is incorrect");
        }

        return _jwtProvider.CreateToken(user, request.RememberMe);
        #endregion
    }


    private void CreatingUserToDatabase(AppUser user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }

    private AppUser CreateUser(RegisterDto request, byte[] passwordSalt, byte[] passwordHash)
    {
        return new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.UserName
        };
    }

    private void CheckUserNameAndEmailIsExists(RegisterDto request)
    {
        var checkUserNameIsExsists = _context.Users.Any(p => p.UserName == request.UserName);
        if (checkUserNameIsExsists)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış");
        }
        var checkEmailIsExists = _context.Users.Any(p => p.Email == request.Email);
        if (checkEmailIsExists)
        {
            throw new ArgumentException("Bu mail adresi daha önce kullanılmış");
        }
    }

    private void CheckValidation<T>(T request)
        where T : class
    {
        string validatorName = typeof(T).FullName + "Validator";
        Type? validatorType = Type.GetType(validatorName);

        if (validatorType == null)
        {
            throw new InvalidOperationException("Validator class not found for " + typeof(T).FullName);
        }

        var validatorInstance = Activator.CreateInstance(validatorType);
        var validateMethod = validatorType.GetMethod("Validate");

        if (validateMethod == null)
        {
            throw new InvalidOperationException("Validate method not found in " + validatorName);
        }

        var result = validateMethod.Invoke(validatorInstance, new object[] { request });

        if (result is FluentValidation.Results.ValidationResult validationResult && !validationResult.IsValid)
        {
            throw new ArgumentException(validationResult.Errors[0].ErrorMessage);
        }
    }

    private void CheckValidation(RegisterDto request)
    {
        var validator = new RegisterDtoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ArgumentException(result.Errors[0].ErrorMessage);
        }
    }

    private void CheckValidation(LoginDto request)
    {
        var validator = new LoginDtoValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ArgumentException(result.Errors[0].ErrorMessage);
        }
    }
}
