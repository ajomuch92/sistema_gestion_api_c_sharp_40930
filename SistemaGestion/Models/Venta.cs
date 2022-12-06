namespace SistemaGestion.Models
{
    public class Venta
    {
        public long Id { get; set; }
        public string? Comentario { get; set; }
        public long IdUsuario { get; set; }
        List<ProductoVendido>? ProductosVendidos { get; set; }
    }

    public class ProductoVendido
    {

    }
}
