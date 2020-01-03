namespace UIInventario.Models
{
    public class ProductoViewModel
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string CodigoBarras { get; set; }
        public string Cantidad { get; set; }
        public string PrecioUnitario { get; set; }
    }
}