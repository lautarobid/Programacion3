using Aplication.Servicies;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el contexto para uso con SQLite
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ServiUserDbConnection")));

// Registrar IUserRepository y su implementación (UserRepository)
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Registrar UserService
builder.Services.AddScoped<UserService>();

// Registrar IUserRepository y su implementación (UserRepository)
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Registrar IBillRepository y BillService
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<BillService>();
// Construir la aplicación después de registrar todos los servicios
var app = builder.Build();

// Registrar UserService
builder.Services.AddScoped<UserService>();

// Registrar IBillRepository y BillService
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<BillService>();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();