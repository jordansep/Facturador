using Facturador.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador.Models.Menus
{
    public class Presentador
    {

        public static void WriteLine(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public static void menu()
        {
            Console.WriteLine("Bienvenido al sistema de facturación");
            Console.WriteLine("1. Registrar factura");
            Console.WriteLine("2. Buscar factura");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Seleccione una opción:");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    // Lógica para registrar factura

                    break;
                case 2:
                    // Lógica para buscar factura
                    break;
                case 3:
                    // Lógica para salir
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }
}
