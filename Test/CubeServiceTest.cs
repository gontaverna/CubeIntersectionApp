using Domain.Entities;
using Domain.Services;

namespace Test
{
    public class CubeServiceTest
    {
        //TEST UNITARIO PARA PROBAR EL CUBESERVICE Y VER SI INTERCEPTA O NO
       
        // SI DA 0 ES PORQUE NO SE TOCAN ENTONCES NO INTERCEPTA. > a 0 SI
        private readonly ICubeService _cubeService;

        //COORDENADAS X Y Z LADO   (valores del cosntructor de Cubo)
        public CubeServiceTest()
        {
            _cubeService = new CubeService();
        }

        [Fact]
        public void CalculateIntersectionNoIntercept()
        {
            var cube1 = new Cube(0, 10, 0, 2);
            var cube2 = new Cube(5, 0, 0, 2);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            Assert.Equal(0, volume);
        }

        [Fact]
        public void CalculateIntersectionIntercept()
        {
            //X Y Z LADO
            var cube1 = new Cube(5, 0, 0, 2);
            var cube2 = new Cube(5, 0, 0, 2);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);
            Assert.Equal(8, volume);
        }

        [Fact]
        public void CalculateIntersectionPartialIntersection()
        {
            var cube1 = new Cube(0, 0, 0, 4);
            var cube2 = new Cube(2, 0, 0, 4);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            Assert.Equal(32, volume);
        }


        [Fact]
        public void CalculateIntersectionNoSize()
        {
            var cube1 = new Cube(0, 0, 0, 0);
            var cube2 = new Cube(0, 0, 0, 2);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            Assert.Equal(0, volume);
        }

        [Fact]
        public void CalculateIntersectionNoSize2()
        {
            var cube1 = new Cube(0, 0, 0, 0);
            var cube2 = new Cube(0, 0, 0, 0);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            Assert.Equal(0, volume);
        }

        [Fact]
        public void CalculateIntersectionSizeNegative()
        {
            var cube1 = new Cube(1, 1, 1, -1);
            var cube2 = new Cube(1, 1, 1, -1);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            Assert.Equal(0, volume);
        }


        [Fact]
        public void CalculateIntersectionNoSizeNegative()
        {
            var cube1 = new Cube(0, 0, 0, -1);
            var cube2 = new Cube(0, 0, 0, -1);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);

            Assert.Equal(0, volume);
        }

        [Fact]
        public void CalculateIntersectionNegative()
        {
            var cube1 = new Cube(-5, -5, -5, 4);
            var cube2 = new Cube(-3, -3, -3, 4);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);
            Assert.Equal(8, volume);
        }


        [Theory]
        [InlineData(0, 0, 0, 2, 1, 0, 0, 2, 4)] 
        [InlineData(0, 0, 0, 2, 0, 1, 0, 2, 4)]   
        [InlineData(0, 0, 0, 2, 0, 0, 1, 2, 4)] 
        public void CalculateIntersectionParameters(
    float x1, float y1, float z1, float s1,
    float x2, float y2, float z2, float s2,
    float volume_valid)
        {
            var cube1 = new Cube(x1, y1, z1, s1);
            var cube2 = new Cube(x2, y2, z2, s2);

            float volume = _cubeService.CalculateIntersection(cube1, cube2);
            Assert.Equal(volume_valid, volume);
        }
    }
}