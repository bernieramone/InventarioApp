using InventarioContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;



namespace Repositroy.RepositoryInventario
{
    public class RepositoryInventarios : Repository<Inventario>, IRepositoryInventarios
    {


        public RepositoryInventarios(InventarioEntities context): base(context)
        {

        }
        public IEnumerable<Inventario> GetInventarioSucursalById(int id)
        {
            try
            {
                var lstSucursales = InventarioContext.Inventarios
                      .Include(p => p.Producto)
                      .Include(s => s.Sucursal)
                      .Where(i => i.IdSucursal == id);
                return lstSucursales;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Inventario> GetAllInventarios()
        {
            var lstSucursales = InventarioContext.Inventarios
                      .Include(p => p.Producto)
                      .Include(s => s.Sucursal);
            
            return lstSucursales;
        }

        public InventarioEntities InventarioContext
        {
            get { return Context as InventarioEntities;  }
        }

    }
}
