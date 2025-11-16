using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    //INTERFAZ DE NUESTROS CASOS DE USO.
    public interface ICubeAppService
    {
        Task<float> CalculateCubeIntersection(int cube1_id, int cube2_id);

        Task<int> CreateCubeAsync(Cube cube);

    }
}
