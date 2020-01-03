using InventarioContext;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repositroy.RepositoryProducto
{
    public class RepositoryProducto : Repository<Producto>, IRepositoryProducto
    {


        public RepositoryProducto(InventarioEntities context): base(context)
        {

        }

        public IEnumerable<Producto> GetAllProducts()
        {
            try
            {
                var lstProductos = InventarioContext.Productos.Include(x => x.Inventarios);
                return lstProductos;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<Producto> GetInventarioSucursalById(int id)
        {
            throw new System.NotImplementedException();
        }

        public InventarioEntities InventarioContext
        {
            get { return Context as InventarioEntities; }
        }
    }
}
