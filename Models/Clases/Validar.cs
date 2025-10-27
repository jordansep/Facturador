using Facturador.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador.Models.Clases
{
    // Hacemos la clase 'public' y 'static' para que sea accesible
    // desde cualquier parte del poyecto sin necesidad de crear un objeto.
    public static class Validar
    {
        /// <summary>
        /// Solicita un texto al usuario y se asegura de que no sea nulo o vacío.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar al usuario (ej: "Ingrese Razón Social: ")</param>
        /// <returns>El texto ingresado por el usuario.</returns>
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
                    // Mostramos un error y el bucle se repetirá
                    Presentador.WriteLine("Error: El valor no puede estar vacío. Intente de nuevo.");
                }
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        /// <summary>
        /// Solicita un número (float) y se asegura de que sea un valor positivo.
        /// Útil para Cantidad, PrecioUnitario e Importes.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar al usuario (ej: "Ingrese Cantidad: ")</param>
        /// <returns>El número (float) válido ingresado.</returns>
        public static float PedirFloatPositivo(string mensaje)
        {
            float valor;
            bool esValido;
            do
            {
                Presentador.WriteLine(mensaje);
                string input = Console.ReadLine();

                // Intentamos convertir el texto a float
                esValido = float.TryParse(input, out valor);

                if (!esValido || valor <= 0)
                {
                    Presentador.WriteLine("Error: Debe ingresar un número positivo. Intente de nuevo.");
                    esValido = false; // Aseguramos que el bucle continúe
                }
            }
            while (!esValido);

            return valor;
        }

        /// <summary>
        /// Solicita una confirmación (Si/No) al usuario.
        /// </summary>
        /// <param name="mensaje">El mensaje de pregunta (ej: "Desea ingresar otro item? (Si/No)")</param>
        /// <returns>true si el usuario responde "SI" o "S", false si responde "NO" o "N".</returns>
        public static bool PedirConfirmacion(string mensaje)
        {
            string input;
            do
            {
                Presentador.WriteLine(mensaje);
                input = Console.ReadLine().Trim().ToUpper(); // Normalizamos la entrada

                if (input == "SI" || input == "S")
                {
                    return true;
                }
                if (input == "NO" || input == "N")
                {
                    return false;
                }

                // Si no es ninguna, mostramos error y el bucle repite
                Presentador.WriteLine("Error: Respuesta no válida. Ingrese 'Si' o 'No'.");
            }
            while (true); // El bucle se rompe con 'return true' o 'return false'
        }

        /// <summary>
        /// Solicita al usuario que elija una de las opciones especificadas.
        /// Útil para el Tipo de Factura (A, B, C).
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar (ej: "Ingrese tipo de Factura (A, B, C): ")</param>
        /// <param name="opcionesValidas">Un array de strings con las opciones permitidas. (ej: new string[] {"A", "B", "C"})</param>
        /// <returns>La opción válida seleccionada por el usuario.</returns>
        public static string PedirOpcion(string mensaje, string[] opcionesValidas)
        {
            string input;
            do
            {
                Presentador.WriteLine(mensaje);
                input = Console.ReadLine().Trim().ToUpper(); // Normalizamos

                // Comparamos si la entrada está en el array de opciones válidas
                if (opcionesValidas.Contains(input))
                {
                    return input; // Es válida, la devolvemos
                }

                // Si no, mostramos error
                Presentador.WriteLine($"Error: Opción no válida. Ingrese una de las siguientes: {string.Join(", ", opcionesValidas)}");
            }
            while (true);
        }
    }
}
