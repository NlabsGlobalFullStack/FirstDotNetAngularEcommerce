// IoC Container (Inversion of Control) kullanımı. Servis bağımlılıklarını yönetir.
using System.Reflection;

// Web uygulamasının temelini oluşturur.
var builder = WebApplication.CreateBuilder(args);

// AutoMapper'ı ekler ve mevcut uygulama derlemesini tarar.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Web API kontrolcülerini ekler.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// API keşfini ve Swagger UI'yi etkinleştirir.
builder.Services.AddSwaggerGen();

// Uygulamanın temelini oluşturur.
var app = builder.Build();

// Uygulama geliştirme ortamında çalışıyorsa Swagger ve Swagger UI'yi kullanır.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirmesini etkinleştirir.
app.UseHttpsRedirection();

// Yetkilendirme kullanımını etkinleştirir.
app.UseAuthorization();

// Kontrolcü eşlemesini yapılandırır ve API endpoint'lerini eşler.
app.MapControllers();

// Uygulamayı çalıştırır.
app.Run();
