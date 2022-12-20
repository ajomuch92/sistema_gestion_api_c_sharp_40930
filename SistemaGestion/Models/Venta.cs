namespace SistemaGestion.Models
{
    public class Venta
    {
        public long Id { get; set; }
        public string? Comentario { get; set; }
        public long IdUsuario { get; set; }
        public List<ProductoVendido>? ProductosVendidos { get; set; }

        public Venta()
        {
            ProductosVendidos = new List<ProductoVendido>();
        }
    }
}
