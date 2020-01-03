using InventarioContext;
using System.Collections.Generic;

namespace Repositroy.RepositoryInventario
{
    public interface IRepositoryInventarios : IRepository<Inventario>
    {
        IEnumerable<Inventario> GetInventarioSucursalById(int id);
        IEnumerable<Inventario> GetAllInventarios();
    }
}
