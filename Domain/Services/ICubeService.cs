using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICubeService
    {
        //INTERFAZ CON LOS METODOS DE DOMINIO DE NUESTRA ENTIDAD
        public float CalculateIntersection(Cube cube1, Cube cube2);
    }
}
