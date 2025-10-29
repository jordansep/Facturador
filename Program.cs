// Estos son tus 'usings', déjalos como están
using Facturador.Models.Clases;
using Facturador.Models.Menus;
using Facturador.Server;
using Microsoft.EntityFrameworkCore;
using Facturador.Interfaces; // Importante
using Facturador.Services; // Importante

// Program.cs

FacturadorDbContext context = new FacturadorDbContext();

// 2. Aplicamos cualquier migración pendiente (¡Importante!)
 context.Database.Migrate();  // <--- DESACTIVADA TEMPORALMENTE

// 3. Creamos los servicios...
ICliente clienteService = new ClienteService(context);
IFactura facturaService = new FacturaService(context); // <-- ¡LÍNEA ACTUALIZADA!
// IFactura facturaService = new FacturaService(context); // Descomenta esto cuando crees FacturaService

// 4. Pasamos los servicios al Presentador
// Por ahora, solo pasamos el clienteService. Pasaremos null para facturaService.
Presentador.IniciarMenu(clienteService, facturaService); // <-- ¡LÍNEA ACTUALIZADA!