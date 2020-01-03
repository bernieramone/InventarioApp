using System.Collections.Generic;

namespace UIInventario.Models
{
    public class SucursalModelView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<ProductoViewModel> Productos { get; set; }
    }
}