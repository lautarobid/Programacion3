﻿using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
    }
}
