using Facturador.Models.Clases; 

namespace Facturador.Interfaces
{
    public interface IFactura
    {
        
        void RegistrarFactura(Factura factura);

        
        Factura BuscarFactura(string numero);
    }
}
