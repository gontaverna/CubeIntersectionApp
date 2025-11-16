using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    // NO AGREGAMOS NADA PORQUE NO NECESITAMOS EN ESTE CASO UN METODO EXTRA PARA LOS CUBOS
    public  interface ICubeRepository : IRepository<Cube>
    {
    }
}
