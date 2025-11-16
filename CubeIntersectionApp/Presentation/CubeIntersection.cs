using Application.Services;
using Domain.Entities;
using Domain.Services;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CubeIntersectionApp.Presentation
{
    public class CubeIntersection
    {

        //obtenemos el servicio con inyeccion de dependencias
        private readonly ICubeAppService _cubeAppService;
        public CubeIntersection(ICubeAppService cubeAppService )
        {
            _cubeAppService = cubeAppService;
        }

        public async Task Calculate()
        {
            Console.WriteLine("--- Cube Intersection ---");

            // PEDIMOS DATOS PARA AMBOS CUBOS, VALIDAMOS QUE SEAN FLOATS Y LOS INICIALIZAMOS.
            try
            {

                //COORDENADAS X Y Z --  LADO
                float x1 = ValidateInputs.ReadFloat("Cube 1 - X: ");
                float y1 = ValidateInputs.ReadFloat("Cube 1 - Y: ");
                float z1 = ValidateInputs.ReadFloat("Cube 1 - Z: ");
                float d1 = ValidateInputs.ReadFloat("Cube 1 - Size: ");

                var cube1_id = await _cubeAppService.CreateCubeAsync(new Cube(x1,y1,z1,d1));

                //COORDENADAS X Y Z --  LADO
                float x2 = ValidateInputs.ReadFloat("Cube 2 - X: ");
                float y2 = ValidateInputs.ReadFloat("Cube 2 - Y: ");
                float z2 = ValidateInputs.ReadFloat("Cube 2 - Z: ");
                float d2 = ValidateInputs.ReadFloat("Cube 2 - Size: ");

                var cube2_id = await _cubeAppService.CreateCubeAsync(new Cube(x2, y2, z2, d2));
       
                // PEDIMOS AL SERVICE QUE CALCULE LA INTERSECTION

                float volumen = await _cubeAppService.CalculateCubeIntersection(cube1_id, cube2_id);

                // SI EL VOLUMEN ES > 0 SIGNIFICA QUE INTERSECTAN (formula de internet)
                // intersectan si se superponen en los 3 ejes 

                if (volumen > 0)
                    Console.WriteLine($"Los cubos se intersectan y su volumen es de : {volumen}");
                else
                    Console.WriteLine($"Los cubos no intersectan.");
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
