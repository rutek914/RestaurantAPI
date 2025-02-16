// konfiguruje web app, np. wczytuje appsettings.json
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline. Midleware

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
