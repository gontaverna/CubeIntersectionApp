using Application.Factories;
using Domain.Entities;
using Domain.Services;
using Infraestructure.Repositories;
using System.Threading.Tasks;

namespace Application.Services
{

    //APLICAMOS LOS METODOS DE LA INTERFAZ, UN CASO DE USO ES CALCULAR LA INTERSECCINO PERO ESTO LO HACE EL SERVICIO DE DOMINIO,
    //DE ACA MANEJAMOS ESTO Y TAMBIEN CREAMOS EN EL REPO NUESTRO CUBO.
    public class CubeAppService : ICubeAppService
    {
        private readonly ICubeService _cubeService;
        private readonly ICubeFactory _cubeFactory;
        private readonly ICubeRepository _cubeRepository;

        public CubeAppService(ICubeService cubeService, ICubeFactory cubeFactory, ICubeRepository cubeRepository)
        {
            _cubeService = cubeService;
            _cubeFactory = cubeFactory;
            _cubeRepository = cubeRepository;
        }

        public async Task<float> CalculateCubeIntersection(int cube1_id, int cube2_id)
        {
            var cube1 = await _cubeRepository.GetByIdAsync(cube1_id);
            var cube2 = await _cubeRepository.GetByIdAsync(cube2_id);

            if (cube1 == null)
                throw new ArgumentException($"ID: {cube1_id} no existe.");
            if (cube2 == null)
                throw new ArgumentException($"ID:  {cube2_id}  no existe.");

            return _cubeService.CalculateIntersection(cube1, cube2);
        }

        public async Task<int> CreateCubeAsync(Cube cube)
        {
            //aca podriamos agregar validaciones para el cubo y en caso de ser correcto lo creamos
            // o si tuviesemos un model recibiriamos el model, y luego mapeo a entidad.

            try
            {
                if (cube != null)
                {
                    cube.Id = Random.Shared.Next(1, int.MaxValue); // podria repetirse, pero para el ejemplo sirve.
                    await _cubeFactory.CreateCubeAsync(cube);
                    return cube.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
      
        }


    }
}
