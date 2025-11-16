using Application.Factories;
using Application.Services;
using Domain.Entities;
using Domain.Services;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //TEST PARA MANEJAR NUESTROS CASOS DE USO 
    public class CubeAppServiceTest
    {

        private readonly CubeRepository  _cubeRepository;
        private readonly CubeService _cubeService;
        private readonly CubeFactory _cubeFactory;
        private readonly CubeAppService _cubeAppService;

        public CubeAppServiceTest()
        {
            _cubeRepository = new CubeRepository();
            _cubeService = new CubeService();
            _cubeFactory = new CubeFactory(_cubeRepository);
            _cubeAppService = new CubeAppService(_cubeService, _cubeFactory, _cubeRepository);
        }

        [Fact]
        public async Task CalculateCubeIntersection()
        {
            var cube1 = new Cube(0, 0, 0, 2);
            var cube2 = new Cube(0, 0, 0, 2);

            await _cubeAppService.CreateCubeAsync(cube1);
            await _cubeAppService.CreateCubeAsync(cube2);
           

            float volume = await _cubeAppService.CalculateCubeIntersection(cube1.Id, cube2.Id);

            Assert.Equal(8, volume); 

        }

        [Fact]
        public async Task CalculateCubeIntersection_0()
        {

            var cube1 = new Cube(0, 0, 0, 2);  
            var cube2 = new Cube(5, 0, 0, 2);

            await _cubeAppService.CreateCubeAsync(cube1);
            await _cubeAppService.CreateCubeAsync(cube2);

            float volume = await _cubeAppService.CalculateCubeIntersection(cube1.Id, cube2.Id);

            // 0
            Assert.Equal(0, volume);
        }

        [Fact]
        public async Task CreateCubeAsync()
        {
            var cube = new Cube(1, 1, 1, 3);

            int id = await _cubeAppService.CreateCubeAsync(cube);

            Assert.True(id > 0);
        }

    }
}
