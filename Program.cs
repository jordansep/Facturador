using Facturador.Models.Clases;
using Facturador.Models.Menus;
using Facturador.Server;
using Microsoft.EntityFrameworkCore;
using Facturador.Interfaces;
using Facturador.Services;


FacturadorDbContext context = new FacturadorDbContext();


try
{
    context.Database.Migrate();
}
catch (Exception ex)
{
    Console.WriteLine($"Error al migrar la base de datos: {ex.Message}");
    Console.WriteLine("Asegúrate de que el archivo Facturador.db no esté bloqueado.");
    Console.ReadKey();
    return; 
}

ICliente clienteService = new ClienteService(context);
IFactura facturaService = new FacturaService(context);

Presentador.IniciarMenu(clienteService, facturaService);