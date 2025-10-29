using Facturador.Interfaces;
using Facturador.Models.Clases;
using Facturador.Models.Menus;
using Facturador.Server;
using Microsoft.EntityFrameworkCore; // Para usar Include

namespace Facturador.Services
{
    public class FacturaService : IFactura
    {
        private readonly FacturadorDbContext _context;

        public FacturaService(FacturadorDbContext context)
        {
            _context = context;
        }

        public void RegistrarFactura(Factura factura)
        {
            try
            {
                // Gracias a EF Core, al agregar la Factura,
                // también se agregarán todos los Items de su lista.
                _context.Facturas.Add(factura);
                _context.SaveChanges();
                Presentador.WriteLine("¡Factura emitida con éxito!");
            }
            catch (Exception ex)
            {
                Presentador.WriteLine($"Error al registrar la factura: {ex.Message}");
            }
        }

        // Lo usaremos en el próximo paso (Consultar Factura)
        public Factura BuscarFactura(string numero)
        {
            try
            {
                // Buscamos la factura por su número
                // Usamos Include para traer los datos del Cliente y los Items
                var factura = _context.Facturas
                                .Include(f => f.Cliente)
                                .Include(f => f.Items)
                                .FirstOrDefault(f => f.Numero == numero);

                return factura; // Devolvemos la factura encontrada (o null si no existe)
            }
            catch (Exception ex)
            {
                Presentador.WriteLine($"Error al buscar la factura: {ex.Message}");
                return null;
            }
        }
    }
}
