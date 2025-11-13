namespace Application.Helpers
{
    public class ValidateInputs
    {
        public static float ReadFloat(string mensaje)
        {
            while (true)
            {
                Console.WriteLine(mensaje);
                if (float.TryParse(Console.ReadLine(), out float valor)) return valor;
                Console.WriteLine("ERROR: Ingrese un número válido");
            }
        }

        public static int ReadInt(string mensaje)
        {
            while (true)
            {
                Console.WriteLine(mensaje);
                if (int.TryParse(Console.ReadLine(), out int valor)) return valor;
                Console.WriteLine("ERROR: Ingrese un número válido");
            }
        }
    }
}
