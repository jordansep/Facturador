// Estos son tus 'usings', déjalos como están
using Facturador.Models.Clases;
using Facturador.Models.Menus;
using Facturador.Server;
using Microsoft.EntityFrameworkCore;

// Este es tu código. Ahora SÍ funcionará.
FacturadorDbContext context = new FacturadorDbContext();
Presentador.menu();
context.Database.Migrate(); 