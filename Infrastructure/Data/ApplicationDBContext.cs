using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }  // Asegúrate de que es plural
        public DbSet<Bill> Bills { get; set; }  // Agrega esta línea para las facturas
        public DbSet<Client> Clients { get; set; } // DbSet para clientes
        public DbSet<TruckDriver> TruckDrivers { get; set; } // Agrega esta línea
        public DbSet<Trip> Trips { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                // Usuario administrador
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    LastName = "User",
                    Email = "admin@gmail.com",
                    Dni = "12345678",
                    Password = "string",
                    Role = Role.Admin
                },
                // Conductor de camión
                new User
                {
                    Id = 2,
                    Name = "John",
                    LastName = "Doe",
                    Email = "driver@gmail.com",
                    Dni = "87654321",
                    Password = "string",
                    Role = Role.TruckDriver
                },
                // Cliente
                new User
                {
                    Id = 3,
                    Name = "Jane",
                    LastName = "Smith",
                    Email = "client@gmail.com",
                    Dni = "11223344",
                    Password = "string",
                    Role = Role.Client
                }
            );
            modelBuilder.Entity<Trip>().HasData(
               new Trip
               {
                   Id = 1,
                   StartingPoint = "Buenos Aires",
                   Destination = "Rosario",
                   DepartureDate = new DateTime(2024, 11, 1, 8, 0, 0), // Fecha de salida: 1 de noviembre de 2024 a las 8:00 AM
                   TruckDriverId = 2, // Relacionado con el TruckDriver con Id 2 (John Doe)
                   ClientId = 3        // Relacionado con el Client con Id 3 (Jane Smith)
               }
           );

            // Seed de una factura (Bill)
            modelBuilder.Entity<Bill>().HasData(
                new Bill
                {
                    Id = 1,
                    Amount = 1500.00f,       // Monto de la factura
                    PayState = PayState.noPago // Estado de pago: Pendiente
                }
            );
        }

    }
}