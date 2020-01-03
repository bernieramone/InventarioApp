using System.Collections.Generic;

namespace InventarioWebApi.Models
{
    public class SucursalModelView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<ProductoViewModel> Productos { get; set; }
        public string Direccion { get; set; }
        public string Zona { get; set; }
    }
}