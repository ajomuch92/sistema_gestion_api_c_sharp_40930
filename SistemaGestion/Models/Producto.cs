namespace SistemaGestion.Models
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }

        public Producto()
        {
            Id = 0;
            Descripcion = "";
            PrecioCompra = 0;
            PrecioVenta = 0;
            Stock = 0;
        }

        public Producto(long codigo, string descripcion, double precioCompra, double precioVenta, int stock)
        {
            Id = codigo;
            Descripcion = descripcion;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            Stock = stock;
        }
    }
}
