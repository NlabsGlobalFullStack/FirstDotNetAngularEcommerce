// IoC Container (Inversion of Control) kullan�m�. Servis ba��ml�l�klar�n� y�netir.
using System.Reflection;

// Web uygulamas�n�n temelini olu�turur.
var builder = WebApplication.CreateBuilder(args);

// AutoMapper'� ekler ve mevcut uygulama derlemesini tarar.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Web API kontrolc�lerini ekler.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// API ke�fini ve Swagger UI'yi etkinle�tirir.
builder.Services.AddSwaggerGen();

// Uygulaman�n temelini olu�turur.
var app = builder.Build();

// Uygulama geli�tirme ortam�nda �al���yorsa Swagger ve Swagger UI'yi kullan�r.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS y�nlendirmesini etkinle�tirir.
app.UseHttpsRedirection();

// Yetkilendirme kullan�m�n� etkinle�tirir.
app.UseAuthorization();

// Kontrolc� e�lemesini yap�land�r�r ve API endpoint'lerini e�ler.
app.MapControllers();

// Uygulamay� �al��t�r�r.
app.Run();
