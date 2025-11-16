using Domain.Entities;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    //FACTORY PARA CREAR EN NUESTRO REPO LOS CUBOS. ACA PODRIAMOS AGREGAR MAS VALIDACIONES EN CASO DE NECESITARLO.
    public class CubeFactory : ICubeFactory
    {
        private readonly ICubeRepository _cubeRepository;

        public CubeFactory(ICubeRepository cubeRepository)
        {
            _cubeRepository = cubeRepository;
        }

        public async Task<Cube> CreateCubeAsync(Cube cube)
        {
            if (cube == null)
                throw new ArgumentNullException(nameof(cube));

            await _cubeRepository.CreateAsync(cube);
            return cube;

        }
    }
}
