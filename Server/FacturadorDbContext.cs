using Facturador.Models.Clases;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador.Server
{
    public class FacturadorDbContext : DbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Factura> Facturas { get; set; }
        DbSet<Item> Items { get; set; }
        public FacturadorDbContext() { 
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Agrega el using necesario para SetBasePath
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                // Obtiene la cadena de conexión
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Usa SQL Server como motor de base de datos
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación: Un Cliente tiene muchas Facturas
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Facturas) // Un cliente tiene una lista de facturas
                .WithOne(f => f.Cliente)  // Cada factura pertenece a un cliente
                .HasForeignKey(f => f.ClienteId); // La clave foránea es ClienteId

            // Relación: Una Factura tiene muchos Items
            modelBuilder.Entity<Factura>()
                .HasMany(f => f.Items) // Una factura tiene una lista de items
                .WithOne(i => i.Factura) // Cada item pertenece a una factura
                .HasForeignKey(i => i.FacturaId); // La clave foránea es FacturaId
        }
    }
}
