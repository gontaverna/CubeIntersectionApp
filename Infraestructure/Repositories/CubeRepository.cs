using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{

    //IMPLEMENTAMOS CON LIST LA PERSISTENCIA DE DATOS CON EL REPOSITORIO. EN CASO DE TENER BD SERVIRIA IGUALMENTE SI APLICAMOS EL CONTEXTO
    public class CubeRepository : ICubeRepository
    {
        private readonly List<Cube> _cubes = new();

        public async Task CreateAsync(Cube entity)
        {
            await Task.Yield();
            _cubes.Add(entity);
        }

        public async Task DeleteAsync(Cube entity)
        {
            await Task.Yield();
            _cubes.Remove(entity);
           
        }

        public IEnumerable<Cube> GetAll()
        {
            return _cubes;
        }

        public Task<IEnumerable<Cube>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Cube>>(_cubes);
        }

        public Task UpdateAsync(Cube entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Cube?> GetByIdAsync(int id)
        {
            await Task.Yield();
            return _cubes.FirstOrDefault(c => c.Id == id);
        }

 
    }
}
