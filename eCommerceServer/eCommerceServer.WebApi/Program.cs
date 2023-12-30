// IoC Container (Inversion of Control) kullanýmý. Servis baðýmlýlýklarýný yönetir.
using eCommerceServer.WebApi.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

// Web uygulamasýnýn temelini oluþturur.
var builder = WebApplication.CreateBuilder(args);

// CORS (Cross-Origin Resource Sharing) ayarlarýný ekler.
builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

// Veritabaný baðlantý dizesini alýr.
//string? connectionString = builder.Configuration.GetConnectionString("SqlServer");

// DbContext için baðlantýyý yapýlandýrýr ve servislere ekler.
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});

// AutoMapper'ý ekler ve mevcut uygulama derlemesini tarar.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Web API kontrolcülerini ekler.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// API keþfini ve Swagger UI'yi etkinleþtirir.
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

// Uygulamanýn temelini oluþturur.
var app = builder.Build();

// Uygulama geliþtirme ortamýnda çalýþýyorsa Swagger ve Swagger UI'yi kullanýr.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

// HTTPS yönlendirmesini etkinleþtirir.
app.UseHttpsRedirection();

// Kontrolcü eþlemesini yapýlandýrýr ve API endpoint'lerini eþler.
app.MapControllers();

// Uygulamayý çalýþtýrýr.
app.Run();
