using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;
using ECommerceServer.WebApi.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceServer.WebApi.Services;

public sealed class JwtProvider
{
    IConfiguration _configuration;
    private readonly Jwt _jwt;

    public JwtProvider(IConfiguration configuration, IOptions<Jwt> jwt)
    {
        _configuration = configuration;
        _jwt = jwt.Value;
    }

    public LoginResponseDto CreateToken(AppUser user, bool rememberMe)
    {
        IEnumerable<Claim> claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim("UserName", user.UserName),
            new Claim("Name", string.Join(user.FirstName, user.LastName)),
            new Claim("IsAdmin", user.IsAdmin.ToString())
        };
        DateTime expires = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);
        string secretKey = _jwt.SecretKey;
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwt.Issuer, //uygulanın kime ait olduğu
            audience: _jwt.Audience, //uygulamayı kimin kullanacağı
            claims: claims, //body alanımız
            notBefore: DateTime.Now, //tokenın ne zaman başlayacağı
            expires: expires, //token ne zaman biteceği
        signingCredentials: credentials); //şifreleme anahtarımız
        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(jwtSecurityToken);
        return new(token, user.Id);
    }
}
