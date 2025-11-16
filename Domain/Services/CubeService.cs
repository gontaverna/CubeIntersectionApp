using Domain.Entities;


namespace Domain.Services
{
    public class CubeService : ICubeService
    {

        /*
         * SI EL VOLUMEN ES > A 0 SIGNIFICA QUE INTERSECTAN
         * FORMULA MATEMATICA PARA CALCULAR ESTO OBTENIDA DE INTERNET
         * APLICAMOS METODOS DE LA INTERFAZ
         */

        public float CalculateIntersection(Cube cube1, Cube cube2)
        {
            float half1 = cube1.Size / 2f;
            float half2 = cube2.Size / 2f;

            float overlapX = CalculateOverlap(cube1.X, half1, cube2.X, half2);
            float overlapY = CalculateOverlap(cube1.Y, half1, cube2.Y, half2);
            float overlapZ = CalculateOverlap(cube1.Z, half1, cube2.Z, half2);

            return overlapX * overlapY * overlapZ;
        }

        private float CalculateOverlap(float center1, float half1, float center2, float half2)
        {
            float maxStart = Math.Max(center1 - half1, center2 - half2);
            float minEnd = Math.Min(center1 + half1, center2 + half2);

            return Math.Max(0, minEnd - maxStart);
        }


    }
}
