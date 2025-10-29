using Facturador.Models.Menus;

namespace Parcial3.Modules
{
    public static class Reader
    {

        public static string ReadString(string prompt)
        {
            string result;
            do
            {
                Presentador.WriteLine($"{prompt}: ");
                result = Console.ReadLine();
                Presentador.WriteLine("");
                if (string.IsNullOrWhiteSpace(result))
                {
                    Presentador.WriteLine("Error: El valor no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(result));
            return result;
        }

        public static int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Presentador.WriteLine($"{prompt}: ");
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    Presentador.WriteLine("");
                    return result;
                }
                Presentador.WriteLine("Error: Formato de número inválido. Por favor, ingrese solo dígitos.");
            }
        }
        public static int ReadInt(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
              
                Presentador.WriteLine($"{prompt} (entre {min} y {max}): ");

                // --- Validación 1: ¿Es un número válido? ---
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    // Si no es un número, damos un error de FORMATO.
                    Presentador.WriteLine("Error: Formato inválido. Por favor, ingrese solo dígitos numéricos.");
                    continue; // Volvemos al inicio del bucle.
                }

                // --- Validación 2: ¿Está en el rango correcto? ---
                // Si llegamos aquí, sabemos que 'result' es un número.
                if (result >= min && result <= max)
                {
                    // Si está en el rango, ¡éxito!
                    return result;
                }
                else
                {
                    // Si no está en el rango, damos un error de RANGO.
                    Presentador.WriteLine($"Error: La opción debe ser un número entre {min} y {max}.");
                }
            }
        }
        public static float ReadFloat(string prompt)
        {
            float result;
            while (true)
            {
                Presentador.WriteLine($"{prompt}: ");
                if (float.TryParse(Console.ReadLine(), out result))
                {
                Presentador.WriteLine("");
                    return result;
                }
                Presentador.WriteLine("Error: Formato de número inválido. Use ',' como separador decimal si es necesario.");
            }
        }

        public static DateTime ReadDate(string prompt)
        {
            DateTime result;
            while (true)
            {
                Presentador.WriteLine($"{prompt}: "); 
                if (DateTime.TryParse(Console.ReadLine(), out result))
                {
                Presentador.WriteLine("");
                    return result;
                }
                Presentador.WriteLine("Error: Formato de fecha inválido. Use un formato reconocido como dd/mm/aaaa.");
            }
        }

        public static char ReadChar(string prompt)
        {
            Presentador.WriteLine($"{prompt}: ");
            var character = Console.ReadKey().KeyChar;
            Presentador.WriteLine("");
            return character;
        }
    }
}
