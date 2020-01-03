namespace UIInventario.Models
{
    public partial class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string CodigoBarras { get; set; }
        public string PrecioUnitario { get; set; }
    }
}