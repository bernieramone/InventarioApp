using InventarioContext;
using Repositroy.RepositoryInventario;
using Repositroy.RepositoryProducto;
using Repositroy.RepositorySucursal;

namespace UnitOfWork
{
    public class UnitOfWorkInventrario : IUnitOfWork
    {
        private readonly InventarioEntities _context;
        public IRepositoryInventarios Inventarios { get; private set; }
        public IRepositorySucursal Sucursales { get; private set; }
        public IRepositoryProducto  Productos { get; private set; }


        public UnitOfWorkInventrario(InventarioEntities context)
        {
            _context = context;
            Inventarios = new RepositoryInventarios(_context);
            Sucursales = new RepositorySucursal(_context);
            Productos = new RepositoryProducto(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
