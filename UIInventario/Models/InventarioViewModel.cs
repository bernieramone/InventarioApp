namespace UIInventario.Models
{
    public class InventarioViewModel
    {
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
}