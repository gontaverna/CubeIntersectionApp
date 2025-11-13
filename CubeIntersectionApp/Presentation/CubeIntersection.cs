using Domain.Entities;
using Domain.Services;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeIntersectionApp.Presentation
{
    public class CubeIntersection
    {

        //obtenemos el servicio con inyeccion de dependencias

        private readonly ICubeService _cubeService;
        public CubeIntersection(ICubeService cubeService)
        {
            _cubeService = cubeService;
        }

        public void Calculate()
        {
            Console.WriteLine("--- Cube Intersection ---");

            // PEDIMOS DATOS PARA AMBOS CUBOS, VALIDAMOS QUE SEAN FLOATS Y LOS INICIALIZAMOS.

            float x1 = ValidateInputs.ReadFloat("Cube 1 - X: ");
            float y1 = ValidateInputs.ReadFloat("Cube 1 - Y: ");
            float z1 = ValidateInputs.ReadFloat("Cube 1 - Z: ");
            float d1 = ValidateInputs.ReadFloat("Cube 1 - Size: ");

            //X Y Z LADO
            var cube1 = new Cube(x1, y1, z1, d1);

            float x2 = ValidateInputs.ReadFloat("Cube 2 - X: ");
            float y2 = ValidateInputs.ReadFloat("Cube 2 - Y: ");
            float z2 = ValidateInputs.ReadFloat("Cube 2 - Z: ");
            float d2 = ValidateInputs.ReadFloat("Cube 2 - Size: ");

            //X Y Z LADO
            var cube2 = new Cube(x2, y2, z2, d2);

            // PEDIMOS AL SERVICE QUE CALCULE LA INTERSECTION

            float volumen = _cubeService.CalculateIntersection(cube1, cube2);

            // SI EL VOLUMEN ES > 0 SIGNIFICA QUE INTERSECTAN (formula de internet)
            // intersectan si se superponen en los 3 ejes 

            if (volumen > 0)
                Console.WriteLine($"Los cubos se intersectan y su volumen es de : {volumen}");
            else
                Console.WriteLine($"Los cubos no intersectan.");

        }

    }
}
