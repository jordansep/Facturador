using Facturador.Models.Clases;

namespace Facturador.Interfaces
{
    public interface ICliente
    {
        void RegistrarCliente(Cliente cliente);
        Cliente BuscarClientePorId(int id);
        Cliente BuscarClientePorRazonSocial(string razonSocial);
        List<Cliente> ListarClientes();
        void ModificarCliente(Cliente cliente);
        void BorrarCliente(Cliente cliente);
    }
}