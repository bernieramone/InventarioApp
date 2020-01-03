using Repositroy.RepositoryInventario;
using Repositroy.RepositoryProducto;
using Repositroy.RepositorySucursal;
using System;

namespace UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryInventarios Inventarios { get; }
        IRepositoryProducto Productos { get; }
        IRepositorySucursal Sucursales { get; }
        
        int Complete();

    }
}
