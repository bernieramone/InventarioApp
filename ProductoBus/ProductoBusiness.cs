using InventarioContext;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;

namespace ProductoBus
{
    public class ProductoBusiness
    {
        private UnitOfWorkInventrario _unitOfWork;

        public ProductoBusiness()
        {
            _unitOfWork = new UnitOfWorkInventrario(new InventarioEntities());

        }

       public List<Producto> GetListProductos()
        {
            var lstProductos = _unitOfWork.Productos.GetAllProducts().ToList();

            return lstProductos;

        }

        public void Create(Producto producto)
        {
            _unitOfWork.Productos.Add(producto);
            _unitOfWork.Complete();
        }


    }
}
