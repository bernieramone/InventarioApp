using InventarioContext; 
using System;
using UnitOfWork;

namespace ConsoleHostTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkInventrario unitOfWork = new UnitOfWorkInventrario(new InventarioEntities());

            var lstProductos = unitOfWork.Inventarios.GetInventarioSucursalById(1);
        
        }
    }
}
