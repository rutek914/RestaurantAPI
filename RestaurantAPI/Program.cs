// konfiguruje web app, np. wczytuje appsettings.json
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<RestaurantSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Run database seeding if necessary
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<RestaurantSeeder>();
    seeder.Seed();  // Seed data
}

// Configure the HTTP request pipeline. Midleware

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
