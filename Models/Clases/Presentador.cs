using Facturador.Models.Clases;
using Facturador.Interfaces; // Para usar las interfaces
using Parcial3.Modules; // Para usar Reader
using System.Globalization; // Para formatos de número

namespace Facturador.Models.Menus
{
    public class Presentador
    {
        
        private static ICliente _clienteService;
        private static IFactura _facturaService; 

        public static void WriteLine(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public static void Pausa()
        {
            WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        
        public static void IniciarMenu(ICliente clienteService, IFactura facturaService)
        {
            _clienteService = clienteService;
            _facturaService = facturaService;

            
            CultureInfo.CurrentCulture = new CultureInfo("es-ES");

            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                WriteLine("--- SISTEMA DE FACTURACIÓN ARCA (Parcial 3) ---");
                WriteLine("================================================");
                WriteLine("1. Gestionar Clientes");
                WriteLine("2. Gestionar Facturas");
                WriteLine("3. Salir");
                WriteLine("================================================");

                int opcion = Reader.ReadInt("Seleccione una opción:", 1, 3);

                switch (opcion)
                {
                    case 1:
                        MenuGestionClientes();
                        break;
                    case 2:
                        MenuGestionFacturas();
                        break;
                    case 3:
                        salir = true;
                        WriteLine("Gracias por usar el sistema. ¡Adiós!");
                        break;
                }
            }
        }

        // --- SECCIÓN DE CLIENTES ---

        private static void MenuGestionClientes()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                WriteLine("--- GESTIÓN DE CLIENTES ---");
                WriteLine("1. Registrar Cliente Nuevo");
                WriteLine("2. Modificar Cliente");
                WriteLine("3. Eliminar Cliente");
                WriteLine("4. Listar Todos los Clientes");
                WriteLine("5. Buscar Cliente por Razón Social");
                WriteLine("6. Volver al Menú Principal");
                WriteLine("=============================");

                int opcion = Reader.ReadInt("Seleccione una opción:", 1, 6);

                switch (opcion)
                {
                    case 1:
                        RegistrarNuevoCliente();
                        break;
                    case 2:
                        ModificarCliente();
                        break;
                    case 3:
                        EliminarCliente();
                        break;
                    case 4:
                        ListarTodosLosClientes();
                        break;
                    case 5:
                        BuscarClientePorRazonSocial();
                        break;
                    case 6:
                        volver = true;
                        break;
                }
                if (!volver)
                {
                    Pausa();
                }
            }
        }

        private static void RegistrarNuevoCliente()
        {
            Console.Clear();
            WriteLine("--- REGISTRAR NUEVO CLIENTE ---");
            string razonSocial = Validar.PedirTextoNoVacio("Ingrese Razón Social:");
            string cuit = Validar.PedirTextoNoVacio("Ingrese CUIT/CUIL:");
            string domicilio = Validar.PedirTextoNoVacio("Ingrese Domicilio:");

            Cliente nuevoCliente = new Cliente(cuit, razonSocial, domicilio);
            _clienteService.RegistrarCliente(nuevoCliente);
        }

        private static void ListarTodosLosClientes()
        {
            Console.Clear();
            WriteLine("--- LISTADO DE CLIENTES REGISTRADOS ---");
            var clientes = _clienteService.ListarClientes();

            if (clientes.Count == 0)
            {
                WriteLine("No hay clientes registrados por el momento.");
            }
            else
            {
                WriteLine(String.Format("{0,-5} | {1,-30} | {2,-15} | {3,-35}", "ID", "Razón Social", "CUIT/CUIL", "Domicilio"));
                WriteLine("-----------------------------------------------------------------------------------------");
                foreach (var cliente in clientes)
                {
                    WriteLine(String.Format("{0,-5} | {1,-30} | {2,-15} | {3,-35}",
                        cliente.Id,
                        cliente.RazonSocial,
                        cliente.CuitCuil,
                        cliente.Domicilio));
                }
            }
        }

        private static void BuscarClientePorRazonSocial()
        {
            Console.Clear();
            WriteLine("--- BUSCAR CLIENTE POR RAZÓN SOCIAL ---");
            string razonSocial = Validar.PedirTextoNoVacio("Ingrese la Razón Social a buscar:");
            var cliente = _clienteService.BuscarClientePorRazonSocial(razonSocial);

            if (cliente == null)
            {
                WriteLine($"No se encontró ningún cliente con la Razón Social: '{razonSocial}'");
            }
            else
            {
                WriteLine("\nCliente Encontrado:");
                WriteLine("=======================");
                WriteLine($"ID:            {cliente.Id}");
                WriteLine($"Razón Social:  {cliente.RazonSocial}");
                WriteLine($"CUIT/CUIL:     {cliente.CuitCuil}");
                WriteLine($"Domicilio:     {cliente.Domicilio}");
            }
        }

        private static void ModificarCliente()
        {
            Console.Clear();
            WriteLine("--- MODIFICAR CLIENTE ---");
            string razonSocial = Validar.PedirTextoNoVacio("Ingrese la Razón Social del cliente a modificar:");
            var cliente = _clienteService.BuscarClientePorRazonSocial(razonSocial);

            if (cliente == null)
            {
                WriteLine($"No se encontró ningún cliente con la Razón Social: '{razonSocial}'");
                return;
            }

            WriteLine("\nDatos actuales del cliente:");
            WriteLine($"Razón Social:  {cliente.RazonSocial}");
            WriteLine($"CUIT/CUIL:     {cliente.CuitCuil}");
            WriteLine($"Domicilio:     {cliente.Domicilio}");
            WriteLine("\nIngrese los nuevos datos:");

            string nuevaRazonSocial = Validar.PedirTextoNoVacio($"Razón Social ({cliente.RazonSocial}):");
            string nuevoCuit = Validar.PedirTextoNoVacio($"CUIT/CUIL ({cliente.CuitCuil}):");
            string nuevoDomicilio = Validar.PedirTextoNoVacio($"Domicilio ({cliente.Domicilio}):");

            cliente.ActualizarDatos(nuevoCuit, nuevaRazonSocial, nuevoDomicilio);
            _clienteService.ModificarCliente(cliente);
        }

        private static void EliminarCliente()
        {
            Console.Clear();
            WriteLine("--- ELIMINAR CLIENTE ---");
            string razonSocial = Validar.PedirTextoNoVacio("Ingrese la Razón Social del cliente a eliminar:");
            var cliente = _clienteService.BuscarClientePorRazonSocial(razonSocial);

            if (cliente == null)
            {
                WriteLine($"No se encontró ningún cliente con la Razón Social: '{razonSocial}'");
                return;
            }

            WriteLine("\nCliente a eliminar:");
            WriteLine($"ID:            {cliente.Id}");
            WriteLine($"Razón Social:  {cliente.RazonSocial}");
            WriteLine($"CUIT/CUIL:     {cliente.CuitCuil}");

            if (Validar.PedirConfirmacion("\n¿Está seguro de que desea eliminar este cliente? (Si/No):"))
            {
                _clienteService.BorrarCliente(cliente);
            }
            else
            {
                WriteLine("Operación cancelada.");
            }
        }

        // --- SECCIÓN DE FACTURAS ---

        private static void MenuGestionFacturas()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                WriteLine("--- GESTIÓN DE FACTURAS ---");
                WriteLine("1. Emitir Nueva Factura");
                WriteLine("2. Consultar Factura");
                WriteLine("3. Volver al Menú Principal");
                WriteLine("============================");

                int opcion = Reader.ReadInt("Seleccione una opción:", 1, 3);

                switch (opcion)
                {
                    case 1:
                        EmitirNuevaFactura();
                        break;
                    case 2:
                        ConsultarFactura();
                        break;
                    case 3:
                        volver = true;
                        break;
                }
                if (!volver)
                {
                    Pausa();
                }
            }
        }

        private static void EmitirNuevaFactura()
        {
            Console.Clear();
            WriteLine("--- EMITIR NUEVA FACTURA ---");

            // 1. Pedir tipo y cliente
            string tipo = Validar.PedirOpcion("Ingrese tipo de Factura (A, B, C): ", new string[] { "A", "B", "C" });
            string razonSocial = Validar.PedirTextoNoVacio("Ingrese Razón Social del Cliente:");

            // 2. Buscar cliente
            Cliente cliente = _clienteService.BuscarClientePorRazonSocial(razonSocial);
            if (cliente == null)
            {
                WriteLine("Error: Cliente no encontrado. No se puede emitir la factura.");
                return;
            }

            // 3. Crear cabecera y mostrarla
            Factura nuevaFactura = new Factura
            {
                Tipo = tipo,
                Numero = GenerarNumeroFactura(),
                Fecha = DateTime.Now,
                ClienteId = cliente.Id,
                Cliente = cliente
            };

            WriteLine("\n--- DATOS DE LA FACTURA ---");
            WriteLine($"Factura:       {nuevaFactura.Tipo}");
            WriteLine($"Numero:        {nuevaFactura.Numero}");
            WriteLine($"Fecha:         {nuevaFactura.Fecha.ToShortDateString()}");
            WriteLine($"Razon Social:  {cliente.RazonSocial}");
            WriteLine($"Cuil/Cuit:     {cliente.CuitCuil}");
            WriteLine($"Domicilio:     {cliente.Domicilio}");
            WriteLine("----------------------------\n");

            // 4. Bucle de Items
            bool agregarOtroItem = true;
            while (agregarOtroItem)
            {
                WriteLine("--- INGRESAR ITEM ---");
                string desc = Validar.PedirTextoNoVacio("Descripción:");
                float cant = Validar.PedirFloatPositivo("Cantidad:");
                float precio = Validar.PedirFloatPositivo("Precio Unitario:");

                Item nuevoItem = new Item(desc, cant, precio);
                nuevaFactura.Items.Add(nuevoItem);

                agregarOtroItem = Validar.PedirConfirmacion("¿Desea ingresar otro item? (Si/No):");
            }

            // 5. Cálculo de total y Vista Previa
            nuevaFactura.ImporteTotal = nuevaFactura.Items.Sum(item => item.Cantidad * item.PrecioUnitario);

            Console.Clear();
            WriteLine("--- VISTA PREVIA DE LA FACTURA ---");
            WriteLine($"Factura:       {nuevaFactura.Tipo}");
            WriteLine($"Numero:        {nuevaFactura.Numero}");
            WriteLine($"Fecha:         {nuevaFactura.Fecha.ToShortDateString()}");
            WriteLine($"Razon Social:  {cliente.RazonSocial}");
            WriteLine($"Cuil/Cuit:     {cliente.CuitCuil}");
            WriteLine($"Domicilio:     {cliente.Domicilio}");
            WriteLine("-----------------------------------");
            WriteLine("Items:");
            WriteLine(String.Format("{0,-30} | {1,-10} | {2,-15} | {3,-15}", "Descripción", "Cantidad", "Precio Unit.", "Subtotal"));
            WriteLine("----------------------------------------------------------------------");
            foreach (var item in nuevaFactura.Items)
            {
                WriteLine(String.Format("{0,-30} | {1,-10:N2} | {2,-15:C2} | {3,-15:C2}",
                    item.Descripcion,
                    item.Cantidad,
                    item.PrecioUnitario,
                    (item.Cantidad * item.PrecioUnitario)));
            }
            WriteLine("----------------------------------------------------------------------");
            WriteLine($"IMPORTE TOTAL: {nuevaFactura.ImporteTotal:C2}"); 
            WriteLine("----------------------------------------------------------------------");


            // 6. Confirmación Final
            if (Validar.PedirConfirmacion("\n¿Desea emitir la factura? (Si/No):"))
            {
                _facturaService.RegistrarFactura(nuevaFactura);
            }
            else
            {
                WriteLine("Operación cancelada. La factura no fue emitida.");
            }
        }

        private static void ConsultarFactura()
        {
            Console.Clear();
            WriteLine("--- CONSULTAR FACTURA ---");
            string numero = Validar.PedirTextoNoVacio("Ingrese el Número de Factura a buscar (ej: 0001-12345678):");

            var factura = _facturaService.BuscarFactura(numero);

            if (factura == null)
            {
                WriteLine($"No se encontró ninguna factura con el número: '{numero}'");
            }
            else
            {
                Console.Clear();
                WriteLine("--- FACTURA ENCONTRADA ---");
                WriteLine($"Factura:       {factura.Tipo}");
                WriteLine($"Numero:        {factura.Numero}");
                WriteLine($"Fecha:         {factura.Fecha.ToShortDateString()}");
                WriteLine($"Razon Social:  {factura.Cliente.RazonSocial}");
                WriteLine($"Cuil/Cuit:     {factura.Cliente.CuitCuil}");
                WriteLine($"Domicilio:     {factura.Cliente.Domicilio}");
                WriteLine("-----------------------------------");
                WriteLine("Items:");
                WriteLine(String.Format("{0,-30} | {1,-10} | {2,-15} | {3,-15}", "Descripción", "Cantidad", "Precio Unit.", "Subtotal"));
                WriteLine("----------------------------------------------------------------------");
                foreach (var item in factura.Items)
                {
                    WriteLine(String.Format("{0,-30} | {1,-10:N2} | {2,-15:C2} | {3,-15:C2}",
                        item.Descripcion,
                        item.Cantidad,
                        item.PrecioUnitario,
                        (item.Cantidad * item.PrecioUnitario)));
                }
                WriteLine("----------------------------------------------------------------------");
                WriteLine($"IMPORTE TOTAL: {factura.ImporteTotal:C2}");
                WriteLine("----------------------------------------------------------------------");
            }
        }

        // Método helper para crear un número de factura
        private static string GenerarNumeroFactura()
        {
            Random rand = new Random();
            string correlativo = rand.Next(1, 99999999).ToString().PadLeft(8, '0');
            return $"0001-{correlativo}";
        }
    }
}



