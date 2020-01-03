using InventarioContext;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;

namespace SucursalBus
{
    public class SucursalBusiness
    {
        UnitOfWorkInventrario _unitOfWork;

        public SucursalBusiness()
        {
            _unitOfWork = new UnitOfWorkInventrario(new InventarioEntities());
        }

        public List<Sucursal> GetAll()
        {
            return _unitOfWork.Sucursales.GetAll().ToList();
        }

        public void Create(Sucursal sucursal)
        {
            _unitOfWork.Sucursales.Add(sucursal);
            _unitOfWork.Complete();
        }

    }
}
