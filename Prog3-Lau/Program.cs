using Aplication.Servicies;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el contexto para uso con SQLite
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ServiUserDbConnection")));

// Registrar servicios y repositorios
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<BillService>();
builder.Services.AddScoped<IBillRepository, BillRepository>();

// Registrar TruckDriverService y su repositorio
builder.Services.AddScoped<TruckDriverService>();
builder.Services.AddScoped<ITruckDriverRepository, TruckDriverRepository>();

// Registrar TripService y su repositorio
builder.Services.AddScoped<TripService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();

// Construir la aplicación después de registrar todos los servicios
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();