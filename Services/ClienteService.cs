using Facturador.Interfaces;
using Facturador.Models.Clases;
using Facturador.Models.Menus; // Para usar Presentador.WriteLine
using Facturador.Server;
using Microsoft.EntityFrameworkCore;

namespace Facturador.Services
{
    public class ClienteService : ICliente
    {
        private readonly FacturadorDbContext _context;

        public ClienteService(FacturadorDbContext context)
        {
            _context = context;
        }

        public Cliente BuscarClientePorId(int id)
        {
            return _context.Clientes.Find(id);
        }

        public Cliente BuscarClientePorRazonSocial(string razonSocial)
        {
            // Usamos ToUpper() para que la búsqueda no distinga mayúsculas/minúsculas
            return _context.Clientes.FirstOrDefault(c => c.RazonSocial.ToUpper() == razonSocial.ToUpper());
        }

        public List<Cliente> ListarClientes()
        {
            return _context.Clientes.ToList();
        }

        public void RegistrarCliente(Cliente cliente)
        {
            try
            {
                // Verificamos si ya existe un cliente con ese CUIT o Razón Social
                var clienteExistente = _context.Clientes.FirstOrDefault(c => c.CuitCuil == cliente.CuitCuil || c.RazonSocial.ToUpper() == cliente.RazonSocial.ToUpper());

                if (clienteExistente != null)
                {
                    Presentador.WriteLine("Error: Ya existe un cliente con esa Razón Social o CUIT.");
                    return;
                }

                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                Presentador.WriteLine("¡Cliente registrado con éxito!");
            }
            catch (Exception ex)
            {
                Presentador.WriteLine($"Error al registrar cliente: {ex.Message}");
            }
        }

        public void ModificarCliente(Cliente cliente)
        {
            try
            {
                // Le decimos a EF que este objeto ha sido modificado
                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();
                Presentador.WriteLine("¡Cliente modificado con éxito!");
            }
            catch (Exception ex)
            {
                Presentador.WriteLine($"Error al modificar cliente: {ex.Message}");
            }
        }

        public void BorrarCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                Presentador.WriteLine("¡Cliente eliminado con éxito!");
            }
            catch (Exception ex)
            {
                // Esto es importante, si el cliente tiene facturas, dará un error
                Presentador.WriteLine($"Error al eliminar cliente: {ex.Message}");
                Presentador.WriteLine("Asegúrese de que el cliente no tenga facturas asociadas.");
            }
        }
    }
}