using Domain.Entities;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //TEST PARA CREAR EL REPOSITORIO LOS METODOS QUE IMPLEMENTAMOS
    public class CubeRepositoryTest
    {
        private readonly CubeRepository _repo = new CubeRepository();

        [Fact]
        public async Task CreateAsync()
        {

            var cube = new Cube(5, 10, 5, 10);
            cube.Id = 1;

            await _repo.CreateAsync(cube);

            var result = await _repo.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);

        }

        
        [Fact]
        public async Task DeleteAsync()
        {
            var cube = new Cube(10, 50, 0, 2);
            cube.Id = 1;
            await _repo.CreateAsync(cube);
            await _repo.DeleteAsync(cube);

            var result = await _repo.GetByIdAsync(1);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync()
        {
            var repo = new CubeRepository();

            var cube1 = new Cube(5, 10, 5, 10);
            var cube2 = new Cube(5, 10, 5, 10);
            cube1.Id = 1;
            cube2.Id = 2;
            await repo.CreateAsync(cube1);
            await repo.CreateAsync(cube2);

            var cubes = await repo.GetAllAsync();

            Assert.NotNull(cubes);
            Assert.Contains(cube1, cubes);
            Assert.Contains(cube2, cubes);
        }
    }
}
