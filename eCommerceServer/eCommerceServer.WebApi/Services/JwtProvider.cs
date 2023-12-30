using eCommerceServer.WebApi.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerceServer.WebApi.Services;

public sealed class JwtProvider
{

    private readonly IConfiguration _configuration;

    public JwtProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string CreateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim("Email", user.Email),
            new Claim("Name", string.Join(" ", user.FirstName, user.LastName)),
        };

        DateTime expires = DateTime.Now.AddMinutes(20);

        JwtSecurityToken jwtToken = new(
            issuer: _configuration.GetSection("Jwt:Issuer").Value,
            audience: _configuration.GetSection("Jwt:Audience").Value,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SecretKey").Value ?? "")), SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(jwtToken);


        return token;
    }
}
