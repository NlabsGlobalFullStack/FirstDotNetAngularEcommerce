using ECommerceServer.WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceServer.WebApi.Services;

public sealed class JwtProvider
{
    IConfiguration _configuration;
    public JwtProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(AppUser user, bool rememberMe)
    {
        IEnumerable<Claim> claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim("UserName", user.UserName),
            new Claim("Name", string.Join(user.FirstName, user.LastName)),
            new Claim("IsAdmin", user.IsAdmin.ToString()),
            new Claim("IsSeller", user.IsSeller.ToString())
        };
        DateTime expires = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SecretKey").Value ?? ""));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken jwtSecurityToken = new(
            //uygulanın kime ait olduğu
            issuer: _configuration.GetSection("Jwt:Issuer").Value,
            //uygulamayı kimin kullanacağı
            audience: _configuration.GetSection("Jwt:Audience").Value,
            //body alanımız
            claims: claims,
            //tokenın ne zaman başlayacağı
            notBefore: DateTime.Now,
            //token ne zaman biteceği
            expires: expires,
            //şifreleme anahtarımız
            signingCredentials: credentials
        );
        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(jwtSecurityToken);
        return token;
    }
}
