using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    //INTERFAZ DE REPOSITORIO CON METODOS COMUNES A IMPLEMENTAR PARA TODAS LAS ENTIDADES, EN CASO DE QUE TENGAMOS MAS
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);

    }
}
