// IoC Container (Inversion of Control) kullan�m�. Servis ba��ml�l�klar�n� y�netir.
using eCommerceServer.WebApi.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

// Web uygulamas�n�n temelini olu�turur.
var builder = WebApplication.CreateBuilder(args);

// CORS (Cross-Origin Resource Sharing) ayarlar�n� ekler.
builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

// Veritaban� ba�lant� dizesini al�r.
//string? connectionString = builder.Configuration.GetConnectionString("SqlServer");

// DbContext i�in ba�lant�y� yap�land�r�r ve servislere ekler.
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});

// AutoMapper'� ekler ve mevcut uygulama derlemesini tarar.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Web API kontrolc�lerini ekler.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// API ke�fini ve Swagger UI'yi etkinle�tirir.
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:SecretKey").Value ?? ""))
    };
});

// Uygulaman�n temelini olu�turur.
var app = builder.Build();

// Uygulama geli�tirme ortam�nda �al���yorsa Swagger ve Swagger UI'yi kullan�r.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

// HTTPS y�nlendirmesini etkinle�tirir.
app.UseHttpsRedirection();

// Kontrolc� e�lemesini yap�land�r�r ve API endpoint'lerini e�ler.
app.MapControllers();

// Uygulamay� �al��t�r�r.
app.Run();
