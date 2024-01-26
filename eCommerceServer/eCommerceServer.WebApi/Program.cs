using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.Repositories;
using ECommerceServer.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(corsPolicy =>
    {
        corsPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddScoped<JwtProvider>();
builder.Services.AddScoped<ShoppingCartRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<SellerRepository>();

string? dbConnectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(dbContextOptions =>
{
    dbContextOptions.UseSqlServer(dbConnectionString);
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swaggerSetup =>
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

    swaggerSetup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    swaggerSetup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
}
    );


builder.Services.AddAuthentication().AddJwtBearer(jwtOptions =>
{
    jwtOptions.TokenValidationParameters = new()
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

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
