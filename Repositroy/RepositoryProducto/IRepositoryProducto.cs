using InventarioContext;
using System.Collections.Generic;

namespace Repositroy.RepositoryProducto
{
    public interface IRepositoryProducto : IRepository<Producto>
    {
        IEnumerable<Producto> GetInventarioSucursalById(int id);
        IEnumerable<Producto> GetAllProducts();
    }
}
