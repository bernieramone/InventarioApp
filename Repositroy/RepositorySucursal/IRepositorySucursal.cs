using InventarioContext;
using System.Collections.Generic;

namespace Repositroy.RepositorySucursal
{
    public interface IRepositorySucursal : IRepository<Sucursal>
    {
        IEnumerable<Producto> GetInventarioSucursalById(int id);
    }
}
