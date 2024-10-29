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
builder.Services.AddScoped<UserService>();
// Registrar IUserRepository y su implementación (UserRepository)
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<BillService>();
// Registrar IBillRepository y BillService
builder.Services.AddScoped<IBillRepository, BillRepository>();


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