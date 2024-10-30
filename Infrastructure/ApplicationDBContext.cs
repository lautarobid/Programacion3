using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }  // Asegúrate de que es plural
        public DbSet<Bill> Bills { get; set; }  // Agrega esta línea para las facturas
        public DbSet<Client> Clients { get; set; } // DbSet para clientes
        public DbSet<TruckDriver> TruckDrivers { get; set; } // Agrega esta línea
        public DbSet<Trip> Trips { get; set; } // DbSet para viajes
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales, si necesitas personalizar las tablas, claves o relaciones.
            modelBuilder.Entity<User>().ToTable("Users"); // Configuración para la tabla de Users
            modelBuilder.Entity<Bill>().ToTable("Bills"); // Configuración para la tabla de Bills
            modelBuilder.Entity<Client>().ToTable("Clients"); // Configuración para la tabla de Clients
            modelBuilder.Entity<TruckDriver>().ToTable("TruckDrivers"); // Configuración para la tabla de TruckDrivers
            modelBuilder.Entity<Trip>().ToTable("Trips"); // Configuración para la tabla de Trips
        }
    }
}