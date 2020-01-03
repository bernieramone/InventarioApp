using InventarioContext;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;

namespace InventarioBus
{
    public class ProductoBusinnes
    {
        private UnitOfWorkInventrario _unitOfWork;
        
        public ProductoBusinnes()
        {
            _unitOfWork = new UnitOfWorkInventrario(new InventarioEntities());
           
        }

        public List<Inventario> GetInventarioByIdSucursal(int id)
        {
            var lstProductos = _unitOfWork.Inventarios.GetInventarioSucursalById(id).ToList(); ;

            if (lstProductos == null || !lstProductos.Any())
            {
                throw new Exception();
            }

            return lstProductos;

        }

        public List<Inventario> GetAllInventarios()
        {
            return _unitOfWork.Inventarios.GetAllInventarios().ToList();
                       
        }





                                 
    }
}
