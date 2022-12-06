namespace SistemaGestion.Models
{
    public class Usuario
    {
        public long? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contrasenia { get; set; }
        public string? Mail { get; set; }
        public string? token { get; set; }
    }
}
