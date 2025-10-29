using Facturador.Models.Clases;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Facturador.Server
{
    public class FacturadorDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Item> Items { get; set; }
        public FacturadorDbContext() { 
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // --- ESTA ES LA LÍNEA QUE CAMBIAMOS ---
                optionsBuilder.UseSqlServer(connectionString);
                // ------------------------------------
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
