namespace backend.Models
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
    }
}
