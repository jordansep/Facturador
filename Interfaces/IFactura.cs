using Facturador.Models.Clases; // <-- ¡Añade este using!

namespace Facturador.Interfaces
{
    public interface IFactura
    {
        // Arreglado: Ahora acepta un objeto Factura
        void RegistrarFactura(Factura factura);

        // Arreglado: Ahora acepta un string y devuelve una Factura
        Factura BuscarFactura(string numero);
    }
}
