using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            float overlapX = Math.Max(0, Math.Min(cube1.X + half1, cube2.X + half2) - Math.Max(cube1.X - half1, cube2.X - half2));
            float overlapY = Math.Max(0, Math.Min(cube1.Y + half1, cube2.Y + half2) - Math.Max(cube1.Y - half1, cube2.Y - half2));
            float overlapZ = Math.Max(0, Math.Min(cube1.Z + half1, cube2.Z + half2) - Math.Max(cube1.Z - half1, cube2.Z - half2));

            return overlapX * overlapY * overlapZ;
        }
    }
}
