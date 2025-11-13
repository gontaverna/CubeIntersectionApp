using System.Runtime.CompilerServices;

namespace Helpers
{
    public class ValidateInputs
    {
        //UN HELPER PARA PEDIR EL INPUT DE DATOS Y VALIDAR QUE SEAN DE TIPO FLOAT.
        //AL SER PARA DATOS DE CONSOLA LO PONEMOS EN LA CAPA DE PRESENTATION TAMBIEN Y NO EN APPLICATION
        public static float ReadFloat(string mensaje)
        {
            while (true)
            {
                Console.WriteLine(mensaje);
                if (float.TryParse(Console.ReadLine(), out float valor)) return valor;
                Console.WriteLine("ERROR: Ingrese un número válido");
            }
        }
    }
}
