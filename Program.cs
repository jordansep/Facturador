

using Facturador.Models.Clases;
using Facturador.Models.Menus;
using Facturador.Server;
using Microsoft.EntityFrameworkCore;


static void Main(string[] args)
{
    FacturadorDbContext context = new FacturadorDbContext();
    Presentador.menu();
    context.Database.Migrate();
}
