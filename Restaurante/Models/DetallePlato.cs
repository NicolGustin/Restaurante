namespace Restaurante.Models
{
    public class DetallePlato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<DetallePlato>? DetallePlatos { get; set; }
    }
}
