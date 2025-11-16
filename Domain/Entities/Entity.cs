using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //LO HACEMOS GENERICO EN CASO DE NECESITAR MAS ENTIDADES PARA QUE SEA ESCALABLE. Y LO AGRGAMOS PARA DEVOLVER UN VALOR EN EL CREATE.
    public class Entity
    {
        public int Id { get; set; }
    }
}
