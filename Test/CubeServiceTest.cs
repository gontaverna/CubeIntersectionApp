using Domain.Entities;
using Domain.Services;

namespace Test
{
    public class CubeServiceTest
    {
        //TEST UNITARIO PARA PROBAR EL CUBESERVICE Y VER SI INTERCEPTA O NO
        // OBTENEMOS EL SERVICE POR INYECCION DE DEPENDENCIAS
        private readonly ICubeService _cubeService;


        public CubeServiceTest()
        {
            _cubeService = new CubeService();
        }

        [Fact]
        public void NoIntercept()
        {
            //X Y Z LADO
            var cube1 = new Cube(0, 10, 0, 2);
            var cube2 = new Cube(5, 0, 0, 2); 

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            // SI DA 0 ES PORQUE NO SE TOCAN ENTONCES NO INTERCEPTA
            Assert.Equal(0, volume);
        }

        [Fact]
        public void Intercept()
        {
            //X Y Z LADO
            var cube1 = new Cube(5, 0, 0, 2);
            var cube2 = new Cube(5, 0, 0, 2);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            // SI DA > 0 ES PORQUE SE TOCAN ENTONCES INTERCEPTA
            // 8 POR QUE ES 2 POR CADA LADO DEL CUBO
            Assert.Equal(8, volume);
        }
    }
}