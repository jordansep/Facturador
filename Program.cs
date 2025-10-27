

using Facturador.Models.Clases;
using Facturador.Server;
using Microsoft.EntityFrameworkCore;

static void Main(string[] args)
{
    FacturadorDbContext context = new FacturadorDbContext();
    context.Database.Migrate();
    Presentador.WriteLine("asdasd");
}
