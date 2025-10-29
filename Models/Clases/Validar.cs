using Facturador.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador.Models.Clases
{
   
    public static class Validar
    {
        
        public static string PedirTextoNoVacio(string mensaje)
        {
            string input;
            do
            {
                // Usamos tu clase Presentador para mostrar el mensaje
                Presentador.WriteLine(mensaje);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    
                    Presentador.WriteLine("Error: El valor no puede estar vacío. Intente de nuevo.");
                }
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
        }

     
        public static float PedirFloatPositivo(string mensaje)
        {
            float valor;
            bool esValido;
            do
            {
                Presentador.WriteLine(mensaje);
                string input = Console.ReadLine();

                
                esValido = float.TryParse(input, out valor);

                if (!esValido || valor <= 0)
                {
                    Presentador.WriteLine("Error: Debe ingresar un número positivo. Intente de nuevo.");
                    esValido = false; 
                }
            }
            while (!esValido);

            return valor;
        }

       
        public static bool PedirConfirmacion(string mensaje)
        {
            string input;
            do
            {
                Presentador.WriteLine(mensaje);
                input = Console.ReadLine().Trim().ToUpper(); 

                if (input == "SI" || input == "S")
                {
                    return true;
                }
                if (input == "NO" || input == "N")
                {
                    return false;
                }

                
                Presentador.WriteLine("Error: Respuesta no válida. Ingrese 'Si' o 'No'.");
            }
            while (true); 
        }

        
        public static string PedirOpcion(string mensaje, string[] opcionesValidas)
        {
            string input;
            do
            {
                Presentador.WriteLine(mensaje);
                input = Console.ReadLine().Trim().ToUpper(); 
                if (opcionesValidas.Contains(input))
                {
                    return input; 
                }

                
                Presentador.WriteLine($"Error: Opción no válida. Ingrese una de las siguientes: {string.Join(", ", opcionesValidas)}");
            }
            while (true);
        }
    }
}
