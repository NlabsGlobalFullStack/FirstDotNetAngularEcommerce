// IoC Container (Inversion of Control) kullanýmý. Servis baðýmlýlýklarýný yönetir.
using System.Reflection;

// Web uygulamasýnýn temelini oluþturur.
var builder = WebApplication.CreateBuilder(args);

// AutoMapper'ý ekler ve mevcut uygulama derlemesini tarar.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Web API kontrolcülerini ekler.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// API keþfini ve Swagger UI'yi etkinleþtirir.
builder.Services.AddSwaggerGen();

// Uygulamanýn temelini oluþturur.
var app = builder.Build();

// Uygulama geliþtirme ortamýnda çalýþýyorsa Swagger ve Swagger UI'yi kullanýr.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirmesini etkinleþtirir.
app.UseHttpsRedirection();

// Yetkilendirme kullanýmýný etkinleþtirir.
app.UseAuthorization();

// Kontrolcü eþlemesini yapýlandýrýr ve API endpoint'lerini eþler.
app.MapControllers();

// Uygulamayý çalýþtýrýr.
app.Run();
