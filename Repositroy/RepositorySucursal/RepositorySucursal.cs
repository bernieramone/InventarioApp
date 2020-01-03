using InventarioContext;
using System.Collections.Generic;


namespace Repositroy.RepositorySucursal
{
    public class RepositorySucursal : Repository<Sucursal>, IRepositorySucursal
    {


        public RepositorySucursal(InventarioEntities context): base(context)
        {

        }

        public IEnumerable<Producto> GetInventarioSucursalById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
